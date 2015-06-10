using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using TrainingsCalendar.Domain.Abstract;
using TrainingsCalendar.Domain.Concrete;
using TrainingsCalendar.WebUI.Infrastructure.Abstract;
using TrainingsCalendar.WebUI.Infrastructure.Concrete;

namespace TrainingsCalendar.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;
        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,
        Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)_ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            _ninjectKernel.Bind<ITrainingsRepository>().To<TrainingsRepository>();
            _ninjectKernel.Bind<ITrainingsStore>().To<TrainingsStore>();
            _ninjectKernel.Bind<IAuthProvider>().To<FormAuthProvider>();
        }
    }
}