using aspnet_crm.Data.Models;
using aspnet_crm.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace aspnet_crm.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        
        Context c = new Context();
        AdminRepository adminRepository = new AdminRepository();

        public IActionResult Index()
        {
            return View(adminRepository.TList());
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdmin(Admin a)
        {
            adminRepository.TAdd(a);
            return RedirectToAction("Index");
        }
        public IActionResult AdminGet(int id)
        {
            var x = adminRepository.TGet(id);
            
            Admin ad = new Admin
            {
                AdminID = x.AdminID,
                Username = x.Username,
                Password = x.Password,
                AdminRole = x.AdminRole
            };
            return View(ad);
        }
        [HttpPost]
        public IActionResult AdminUpdate(Admin p)
        {
            var x = adminRepository.TGet(p.AdminID);
            x.Username = p.Username;
            x.Password = p.Password;
            x.AdminRole = p.AdminRole;
            adminRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAdmin(int id)
        {
            adminRepository.TDelete(new Admin { AdminID = id });
            return RedirectToAction("Index");
        }
    }
}
