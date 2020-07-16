using System.Web.Http;
using WebActivatorEx;
using FashionShopAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace FashionShopAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
              .EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"))
              .EnableSwaggerUi();
        }
    }
}
