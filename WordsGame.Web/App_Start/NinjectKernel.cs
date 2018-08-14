using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordsGame.Data.Interfaces;
using WordsGame.Data.Repositories;
using WordsGame.Services;
using WordsGame.Services.Interfaces;

namespace WordsGame.Web.App_Start
{
    /// <summary>
    /// Static class used to create a shared Kernel object for both NinjectMvc and NinjectWebApi Resolvers
    /// </summary>
    public static class NinjectKernel
    {
        private static readonly IKernel _kernel = new StandardKernel(NinjectHttpModules.Modules);

        public static IKernel GetKernel()
        {
            //To avoid a know issue of Ninject with Mvc validator
            _kernel.Unbind<ModelValidatorProvider>();

            return _kernel;
        }
    }

    // List and Describe Necessary HttpModules
    public class NinjectHttpModules
    {
        //Return Lists of Modules in the Application
        public static NinjectModule[] Modules
        {
            get
            {
                return new[] { new MainModule() };
            }
        }

        //Main Module For Application
        public class MainModule : NinjectModule
        {
            public override void Load()
            {
                this.Bind<IRoundRepository>().To<RoundRepository>();
                this.Bind<IUserRepository>().To<UserRepository>();
                this.Bind<IGameService>().To<GameService>();
            }
        }
    }
}