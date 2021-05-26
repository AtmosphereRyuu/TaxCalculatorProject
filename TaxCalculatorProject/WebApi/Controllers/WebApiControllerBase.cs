using Common.WebApiModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public abstract class WebApiControllerBase: ControllerBase
    {
        protected ControllerErrorModel BuildControllerErrorModel(string errorMessage)
        {
            var model = new ControllerErrorModel(errorMessage);
            return model;
        }
    }
}
