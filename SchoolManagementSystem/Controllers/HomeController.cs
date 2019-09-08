using EntityFramework.Extensions;
using NHAMIS;
using NHAMISAPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        NHAMISContext dbcontext = new NHAMISContext();

        private int CountNumberOfItems(string ModelName)
        {
            int count = 0;
            switch (ModelName.ToLower())
            {
                case "county":
                    count = dbcontext.Counties.Count();
                    break;

                case "constituency":
                    count = dbcontext.SubCounties.Count();
                    break;

                case "ward":
                    count = dbcontext.Wards.Count();
                    break;

                default:
                    count = 0;
                    break;
            }
            return count;
        }

        public ActionResult Index()
        {
            //dbcontext.Database.ExecuteSqlCommand("TRUNCATE TABLE [PostalCode]");
            
            if (CountNumberOfItems("County") <= 0)
            {
                ModelService.InsertCounty();
            }
            if (CountNumberOfItems("Constituency") <= 0)
            {
                ModelService.InsertConstituency();
            }
            if (CountNumberOfItems("Ward") <= 0)
            {
                ModelService.InsertWard();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}