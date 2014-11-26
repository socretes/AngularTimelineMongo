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

            ApplyDebugConfig();

            EnableValidation(container);

            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

            container.RegisterAutoWired<TimelineRepository>().ReusedWithin(ReuseScope.Request);

            container.RegisterAutoWired<EventRepository>().ReusedWithin(ReuseScope.Request);

            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());
            ConfigureAuth(container);

            //Set MVC to use the same Funq IOC as ServiceStack
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


        private void ConfigureAuth(Container container)
        {
            //Enable and register existing services you want this host to make use of.
            //Look in Web.config for examples on how to configure your oauth providers, e.g. oauth.facebook.AppId, etc.
            var appSettings = new AppSettings();

            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
                    new IAuthProvider[] {
                        new TwitterAuthProvider(appSettings), //HTML Form post of User/Pass
                    }
                ));

            //Provide service for new users to register so they can login with supplied credentials.
            Plugins.Add(new RegistrationFeature());

            var authRepo = CreatAuthRepo(container, appSettings);
 
            Plugins.Add(new RequestLogsFeature());
        }

        private IUserAuthRepository CreatAuthRepo(Container container, AppSettings appSettings)
        {
            var mongoClient = new MongoClient("mongodb://jonathan_dudgeon:jonathan_dudgeon@ds053080.mongolab.com:53080/jonsmongodb");
            var server = mongoClient.GetServer();
            var db = server.GetDatabase("jonsmongodb");

            container.Register<IAuthRepository>(c =>
                new MongoDbAuthRepository(db, true));

            var authRepo = (MongoDbAuthRepository)container.Resolve<IAuthRepository>();
      
            return authRepo;
        }
    }
}