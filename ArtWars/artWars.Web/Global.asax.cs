using artWars.Domain.Entities.User;
using artWars.Web.Models;
using AutoMapper;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace artWars.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
			Mapper.Initialize(cfg => {
				cfg.CreateMap<UserLogin, ULoginData>();
				cfg.CreateMap<UDBTable, UserMinimal>();
			});

			BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}