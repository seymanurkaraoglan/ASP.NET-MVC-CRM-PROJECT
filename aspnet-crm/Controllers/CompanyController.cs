using aspnet_crm.Data.Models;
using aspnet_crm.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace aspnet_crm.Controllers
{
    public class CompanyController : Controller
    {
        CompanyRepository companyRepository = new CompanyRepository();
        Context c = new Context();
        public IActionResult Index(int page = 1)
        {
            return View(companyRepository.TList("Category").ToPagedList(page,3));
        }
        [HttpGet]
        public IActionResult AddCompany()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddCompany(Company p)
        {
            companyRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCompany(int id)
        {
            companyRepository.TDelete(new Company { CompanyID = id});
            return RedirectToAction("Index");
        }
        public IActionResult CompanyGet(int id)
        {
            var x = companyRepository.TGet(id);
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            Company cp = new Company
            { 
                CompanyID = x.CompanyID,
                CategoryID = x.CategoryID,
                Name = x.Name,
                Giro = x.Giro,
                Description = x.Description,
                ImageURL = x.ImageURL
            };
            return View(cp);
        }
        
        public IActionResult CompanyDetail(int id)
        {
            var cp = companyRepository.TGet(id);
           
            return View(cp);
        }
        [HttpPost]
        public IActionResult CompanyUpdate(Company p)
        {
            var x = companyRepository.TGet(p.CompanyID);
            x.Name = p.Name;
            x.Giro = p.Giro;
            x.ImageURL = p.ImageURL;
            x.Description = p.Description;
            x.CategoryID = p.CategoryID;
            companyRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
