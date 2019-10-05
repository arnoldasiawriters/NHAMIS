using NHAMIS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using NHAMIS.APP.Models;

namespace NHAMISAPP
{
    public static class ModelService
    {

        public static void InsertCounty()
        {
            using (NHAMISContext dbcontext = new NHAMISContext())
            {
                string path = HttpContext.Current.Server.MapPath(@"~/Models/Initialisation/Counties.txt");

                string[] Counties = File.ReadAllLines(path);

                foreach (string CountyLine in Counties)
                {
                    string countyName = CountyLine;
                    County County = new County() { CountyName = countyName };

                    dbcontext.Counties.Add(County);
                }
                dbcontext.SaveChanges();
            }
        }

        public static void InsertConstituency()
        {
            using (NHAMISContext dbcontext = new NHAMISContext())
            {
                string path = HttpContext.Current.Server.MapPath(@"~/Models/Initialisation/Constituencies.txt");

                string[] Constituencies = File.ReadAllLines(path);

                foreach (string ConstituencyLine in Constituencies)
                {
                    string constituencyName = ConstituencyLine.Split('=')[0];

                    string countyName = ConstituencyLine.Split('=')[1];

                    var CountyId = dbcontext.Counties.Where(n => n.CountyName == countyName).Select(f => f.Id).FirstOrDefault();

                    County County = dbcontext.Counties.Find(CountyId);

                    SubCounty Constituency = new SubCounty() { SubCountyName = constituencyName, County = County };

                    dbcontext.SubCounties.Add(Constituency);
                }
                dbcontext.SaveChanges();
            }
        }

        public static void InsertWard()
        {
            using (NHAMISContext dbcontext = new NHAMISContext())
            {
                string path = HttpContext.Current.Server.MapPath(@"~/Models/Initialisation/Wards.txt");

                string[] Wards = File.ReadAllLines(path);

                foreach (string WardLine in Wards)
                {
                    string wardName = WardLine.Split('=')[0];

                    string constituencyName = WardLine.Split('=')[1];

                    var ConstituencyId = dbcontext.SubCounties.Where(n => n.SubCountyName == constituencyName).Select(c => c.Id).FirstOrDefault();

                    SubCounty Constituency = dbcontext.SubCounties.Find(ConstituencyId);

                    Ward Ward = new Ward() { WardName = wardName, Subcounty = Constituency };

                    dbcontext.Wards.Add(Ward);
                }
                dbcontext.SaveChanges();
            }
        }
        public static void InsertPostalCodes()
        {
            using (NHAMISContext dbcontext = new NHAMISContext())
            {
                string path = HttpContext.Current.Server.MapPath(@"~/Models/Initialisation/PostalCodesKenya.txt");

                string[] postalCodesFile = File.ReadAllLines(path);

                foreach (string postalCodeLine in postalCodesFile)
                {
                    string postalNameText = (postalCodeLine.Split('-')[0]).ToUpper();
                    int postalCodeText = Int32.Parse(postalCodeLine.Split('-')[1]);

                    PostalCode postalCode = new PostalCode() { Code = postalCodeText, Town = postalNameText };
                    dbcontext.PostalCodes.Add(postalCode);
                }
                dbcontext.SaveChanges();
            }
        }
    }
}