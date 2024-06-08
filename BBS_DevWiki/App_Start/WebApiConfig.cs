using BBS_DevWiki.Repositories;
using BBS_DevWiki.Services;
using BBS_DevWiki.Models;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using BBS_DevWiki.App_Start;

namespace BBS_DevWiki
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();

            container.RegisterType<DBContext>(new HierarchicalLifetimeManager());

            container.RegisterType<IArticleTypeRepository, ArticleTypeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IArticleRepository, ArticleRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IArticleTypeService, ArticleTypeService>(new HierarchicalLifetimeManager());
            container.RegisterType<IArticleService, ArticleService>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
