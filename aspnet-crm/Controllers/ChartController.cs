using aspnet_crm.Data;
using aspnet_crm.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_crm.Controllers
{
    public class ChartController : Controller
    {
        //google pie chart static
        public IActionResult Index()
        {
            return View();
        }
        //google column chart static
        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult VisualizeCompanyResult()
        {
            return Json(ProList());
        }

        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                comname = "Agaoglu",
                giro = 1000
            });
            cs.Add(new Class1()
            {
                comname = "Seyhanlar",
                giro = 600
            });
            cs.Add(new Class1()
            {
                comname = "Beta Tech",
                giro = 1500
            });
            return cs;
        }
        //dynamic google chart
        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult VisualizeCompanyResult2()
        {
            return Json(CompanyList());
        }
        public List<Class2> CompanyList()
        {
            List<Class2> cs2 = new List<Class2>();
            using (var c = new Context())
            {
                cs2 = c.Companies.Select(x => new Class2
                {
                    companyname = x.Name,
                    giro = x.Giro
                }).ToList();
            }
            return cs2;
        }
        public IActionResult Statistics()
        {
            Context c = new Context();
            //total company count
            var totalCom = c.Companies.Count();
            ViewBag.d1 = totalCom;
            
            //total category count
            var totalCat = c.Categories.Count();
            ViewBag.d2 = totalCat;

            var buildingid = c.Categories.Where(x => x.CategoryName == "Building").Select(y => y.CategoryID).FirstOrDefault();

            var sumBuilding = c.Companies.Where(x => x.CategoryID == buildingid).Count();
            ViewBag.d3 = sumBuilding;

            var sumTextile = c.Companies.Where(x => x.CategoryID == c.Categories.Where(z => z.CategoryName == "Textile").Select(y => y.CategoryID).FirstOrDefault()).Count();
            ViewBag.d4 = sumTextile;

            var totalGiro = c.Companies.Sum(x => x.Giro);
            ViewBag.d5 = totalGiro;

            var sumTechCount = c.Companies.Where(x => x.CategoryID == c.Categories.Where(y => y.CategoryName == "Technology").Select(x => x.CategoryID).FirstOrDefault()).Count();
            ViewBag.d6 = sumTechCount;

            var maxgirocom = c.Companies.OrderByDescending(x => x.Giro).Select(y => y.Name).FirstOrDefault();
            ViewBag.d7 = maxgirocom;

            var mingiro = c.Companies.OrderBy(x => x.Giro).Select(y => y.Name).FirstOrDefault();
            ViewBag.d8 = mingiro;

            var averageGiro = c.Companies.Average(x => x.Giro).ToString("0.00");
            ViewBag.d9 = averageGiro;

            var foodid = c.Categories.Where(x => x.CategoryName == "Food").Select(y => y.CategoryID).FirstOrDefault();
            var sumoffoodgiro = c.Companies.Where(y => y.CategoryID == foodid).Sum(x => x.Giro);
            ViewBag.d10 = sumoffoodgiro;

            var techid = c.Categories.Where(x => x.CategoryName == "Technology").Select(y => y.CategoryID).FirstOrDefault();
            var sumoftechgiro = c.Companies.Where(y => y.CategoryID == techid).Sum(x => x.Giro);
            ViewBag.d11 = sumoftechgiro;

            return View();

        }
        }
}
