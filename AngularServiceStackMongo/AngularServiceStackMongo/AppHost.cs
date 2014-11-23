namespace AngularServiceStackMongo.Web
{
    using AngularServiceStackMongo.Domain;
    using AngularServiceStackMongo.ServiceInterface;
    using Funq;
    using ServiceStack;
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

            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());

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
    }
}