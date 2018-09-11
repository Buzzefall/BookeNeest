﻿using System.Web.Optimization;

namespace BookeNeest.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Scripts
            //////////////////////////////////////////////////////////
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));
            
            // Custom Scripts:
            //////////////////////////////////////////////////////////
            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                "~/Scripts/select2.js"));





            // Styles
            //////////////////////////////////////////////////////////
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            // Custom styles:
            //////////////////////////////
            bundles.Add(new StyleBundle("~/Content/Custom").Include(
                "~/Content/Custom/book-styles.css",
                "~/Content/css/select2.css"));
        }
    }
}