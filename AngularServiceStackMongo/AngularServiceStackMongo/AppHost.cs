namespace AngularServiceStackMongo.Web
{
    using AngularServiceStackMongo.Domain;
    using AngularServiceStackMongo.ServiceInterface;
    using Funq;
    using MongoDB.Driver;
    using ServiceStack;
    using ServiceStack.Auth;
    using ServiceStack.Authentication.MongoDb;
    using ServiceStack.Configuration;
    using ServiceStack.Mvc;
    using ServiceStack.Validation;
    using System.Web.Mvc;
    using TweetSharp;

    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Default constructor.
        /// Base constructor requires a name and assembly to locate web service classes. 
        /// </summary>
        public AppHost()
            : base("AngularServiceStackMongo", typeof(TimelineService).Assembly)
        {

        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        /// <param name="container"></param>
        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                HandlerFactoryPath = "api",
            });

            var appSettings = new AppSettings();

            ApplyDebugConfig();

            EnableValidation(container);

            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

            RegisterRepositories(container);

            RegisterAuth(container, appSettings);
            
            RegisterTweetService(container, appSettings);

            RegisterControllerFactory(container);
        }

        private static void RegisterRepositories(Container container)
        {
            container.RegisterAutoWired<TimelineRepository>().ReusedWithin(ReuseScope.Request);

            container.RegisterAutoWired<EventRepository>().ReusedWithin(ReuseScope.Request);
        }

        private static void RegisterControllerFactory(Container container)
        {
            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
        }

        private void EnableValidation(Container container)
        {
            this.Plugins.Add(new ValidationFeature());
            container.RegisterValidators(typeof(AngularServiceStackMongo.ServiceModel.Type.TimelineValidator).Assembly);
        }

        private void ApplyDebugConfig()
        {
            #if DEBUG
                //e.g return stack trace with error responses
                this.Config.DebugMode = true;
            #endif
        }


        private void RegisterAuth(Container container, AppSettings appSettings)
        {
            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
                    new IAuthProvider[] {
                        new TwitterAuthProvider(appSettings), //HTML Form post of User/Pass
                    }
                ));

            //Provide service for new users to register so they can login with supplied credentials.
            Plugins.Add(new RegistrationFeature());

            CreatAuthRepo(container, appSettings);
 
            Plugins.Add(new RequestLogsFeature());
        }

        private void CreatAuthRepo(Container container, AppSettings appSettings)
        {
            var connectionString = appSettings.Get("MongoDBConnection");
            var mongoApp = appSettings.Get("MongoApp");
            var mongoClient = new MongoClient(connectionString);
            var server = mongoClient.GetServer();
            var db = server.GetDatabase(mongoApp);

            container.Register<IAuthRepository>(c =>
                new MongoDbAuthRepository(db, true));
        }

        private void RegisterTweetService(Container container, AppSettings appSettings)
        {
            var consumerAppKey = appSettings.Get("oauth.twitter.ConsumerKey");
            var consumerAppSecret = appSettings.Get("oauth.twitter.ConsumerSecret");
            var twitterApp = new TwitterService(consumerAppKey, consumerAppSecret);

            container.Register<ITwitterService>(c => twitterApp);
        }
    }
}