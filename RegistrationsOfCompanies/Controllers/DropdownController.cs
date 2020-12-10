using RegistrationsOfCompanies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationsOfCompanies.Controllers
{
    public class DropdownController : Controller
    {
        private companies_registrationEntities db = new companies_registrationEntities();
        // GET: Dropdown
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCountries()
        {
            var lst = db.countries.ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProvinces()
        {
            var lst = db.provinces.ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDistricts()
        {
            var lst = db.districts.ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetPositions()
        {
            var lst = db.positions.Select(p=>new { position_id = p.position_id, position_title = p.position_title }).ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetSkills()
        {
            var lst = db.skills.Select(p => new { skill_id = p.skill_id, skill_name = p.skill_name }).ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}