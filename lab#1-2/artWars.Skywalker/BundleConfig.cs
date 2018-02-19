using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace artWars.Skywalker
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include("~/Content/bootstrap.min.css",
                new CssRewriteUrlTransform()));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include("~/Scripts/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery-ui.min.js"));
            bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include("~/Content/font-awesome.min.css",
                new CssRewriteUrlTransform()));
        }
    }
}