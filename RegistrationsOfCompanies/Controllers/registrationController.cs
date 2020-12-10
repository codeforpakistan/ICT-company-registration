using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegistrationsOfCompanies.Models;

namespace RegistrationsOfCompanies.Controllers
{
    public class registrationController : Controller
    {
        private companies_registrationEntities db = new companies_registrationEntities();

        // GET: registration
        public ActionResult Index()
        {
            return View(db.basic_detail.ToList());
        }

        //// GET: registration/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    basic_detail basic_detail = db.basic_detail.Find(id);
        //    if (basic_detail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(basic_detail);
        //}

        // GET: registration/Create
        public ActionResult Create()
        {
            ViewBag.is_company = new SelectList(Dropdowns.Company, "Value", "Text");
            ViewBag.basic_country_id = new SelectList(db.countries.ToList(), "country_id", "country_name",157);
            ViewBag.basic_province_id = new SelectList(db.provinces.ToList(), "province_id", "province_name");
            ViewBag.basic_district_id = new SelectList(db.districts.ToList(), "district_id", "district_name");
            ViewBag.principal_country_id = new SelectList(db.countries.ToList(), "country_id", "country_name",157);
            ViewBag.principal_province_id = new SelectList(db.provinces.ToList(), "province_id", "province_name");
            ViewBag.principal_district_id = new SelectList(db.districts.ToList(), "district_id", "district_name");
            ViewBag.business_in_kp_district_id = new SelectList(db.districts.ToList(), "district_id", "district_name");
            ViewBag.city_in_kp = new SelectList(db.cities.ToList(), "CityId", "CityName");

            ViewBag.registration_with = new SelectList(Dropdowns.RegistrationWith, "Value", "Text");
            ViewBag.registration_with_pseb = new SelectList(Dropdowns.RegistrationWithPseb, "Value", "Text");
           


            ViewBag.designation_id = new SelectList(db.positions.ToList(), "position_id", "position_title");
            ViewBag.Skills = new SelectList(db.skills.ToList(), "skill_id", "skill_name");

            registration_vm rvm = new registration_vm();

            var dev_Areas = db.ServicesAreas.Where(x => x.AreaType == "DEV").ToList();
            var lstdev = new List<MultiCheckListBox>();
            foreach (var da in dev_Areas)
            {
                lstdev.Add(new MultiCheckListBox()
                {
                    Checked = false,
                    ID = da.AreaID,
                    DisplayLabel = da.AreaName,
                    checkboxOnClick = ""

                });
            }
            rvm.DevArea = lstdev;

            var Bpo_Areas = db.ServicesAreas.Where(x => x.AreaType == "BPO").ToList();
            var lstbpo = new List<MultiCheckListBox>();
            foreach (var da in Bpo_Areas)
            {
                lstbpo.Add(new MultiCheckListBox()
                {
                    Checked = false,
                    ID = da.AreaID,
                    DisplayLabel = da.AreaName,
                    checkboxOnClick = ""

                });
            }
            rvm.BpoArea = lstbpo;

            var Product_Areas = db.ServicesAreas.Where(x => x.AreaType == "Prod").ToList();
            var lstproduct = new List<MultiCheckListBox>();
            foreach (var prod in Product_Areas)
            {
                lstproduct.Add(new MultiCheckListBox()
                {
                    Checked = false,
                    ID = prod.AreaID,
                    DisplayLabel = prod.AreaName,
                    checkboxOnClick = ""

                });
            }
            rvm.ProductArea = lstproduct;
            return View(rvm);
        }

        // POST: registration/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(registration_vm model, int[] Skills, List<MultiCheckListBox> BpoArea, List<MultiCheckListBox> DevArea, List<MultiCheckListBox> ProductArea)
        {

            //basic details
            basic_detail details = new basic_detail();
            details.name = model.person_name;
            details.is_company = model.is_company;
            details.email_address = model.basic_email_address;
            details.mobile_number = model.basic_mobile_number;
            details.phone_number = model.basic_phone_number;
            details.country_id = model.basic_country_id;
            details.province_id = model.basic_province_id;
            details.district_id = model.basic_district_id;
            details.address = model.basic_address;
            details.other_details = model.basic_other_details;
            db.basic_detail.Add(details);
            db.SaveChanges();
            int basis_detail_id = details.basic_id;

            if (model.is_company == 1)
            {
                // business detail
                business_detail business = new business_detail();
                business.basic_id = basis_detail_id;
                business.company_name = model.company_name;
                business.principal_country_id = model.principal_country_id;
                business.princiapal_province_id = model.principal_province_id;
                business.principal_distict_id = model.principal_district_id;
                business.business_in_kp_district_id = model.business_in_kp_district_id;
                business.city_in_kp = model.city_in_kp;
                business.comapy_website = model.comapy_website;
                business.business_email = model.business_email;
                business.contact_person_name = model.contact_person_name;
                business.office_number = model.office_number;
                business.principal_address = model.principal_address;
                business.regional_office_address = model.regional_office_address;
                business.no_of_employees = model.no_of_employees;
                business.operational_since = model.operational_since;
                business.registration_with_pseb = model.registration_with_pseb;
                business.company_short_description = model.company_short_description;
                business.hardware_info = model.hardware_info;
                business.other_service_detail = model.other_service_detail;
                db.business_detail.Add(business);
                db.SaveChanges();
             
                //employee details

                //foreach(employees_vm emp in model.Employee_vm)
                //{
                //    employee_detail obj = new employee_detail();
                //    obj.designation_id = emp.designation_id;
                //    obj.basic_id = basis_detail_id;
                //    obj.designation_id = model.designation_id;
                //    obj.number_of_resources = model.number_of_resources;
                //    if (ModelState.IsValid)
                //    {
                //        db.employee_detail.Add(obj);
                //        db.SaveChanges();
                //    }
                //    int id = emp.employee_id;
                //    if (Skills != null && Skills.Length > 0)
                //    {
                //        List<employee_skills> lstSkills = new List<employee_skills>();
                //        foreach (int sk in Skills)
                //        {
                //            lstSkills.Add(new employee_skills() { employee_id = id, skill_id = sk });
                //        }
                //        db.employee_skills.AddRange(lstSkills);
                //        db.SaveChanges();
                //    }
                //}

               // 
                

                BpoArea = model.BpoArea.Where(x => x.Checked == true).ToList();
                List<dev_bpo_area> bpo_Areas = new List<dev_bpo_area>();
                foreach (MultiCheckListBox r in BpoArea)
                    bpo_Areas.Add(new dev_bpo_area() { AreaID = r.ID, basic_ID = basis_detail_id });
                if (BpoArea.Count > 0)
                {
                    db.dev_bpo_area.AddRange(bpo_Areas);
                    db.SaveChanges();
                }
                DevArea = model.DevArea.Where(x => x.Checked == true).ToList();
                List<dev_bpo_area> dev_area = new List<dev_bpo_area>();
                foreach (MultiCheckListBox r in DevArea)
                    dev_area.Add(new dev_bpo_area() { AreaID = r.ID, basic_ID = basis_detail_id });
                if (DevArea.Count > 0)
                {
                    db.dev_bpo_area.AddRange(dev_area);
                    db.SaveChanges();
                }
                ProductArea = model.ProductArea.Where(x => x.Checked == true).ToList();
                List<dev_bpo_area> Prod_Area = new List<dev_bpo_area>();
                foreach (MultiCheckListBox r in ProductArea)
                    Prod_Area.Add(new dev_bpo_area() { AreaID = r.ID, basic_ID = basis_detail_id });
                if (ProductArea.Count > 0)
                {
                    db.dev_bpo_area.AddRange(Prod_Area);
                    db.SaveChanges();
                }

                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");

               // return RedirectToAction("AddEmployee", new { basicid = basis_detail_id });
            }
            if (model.is_company == 2)
            {
                BpoArea = model.BpoArea.Where(x => x.Checked == true).ToList();
                List<dev_bpo_area> bpo_Areas = new List<dev_bpo_area>();
                foreach (MultiCheckListBox r in BpoArea)
                    bpo_Areas.Add(new dev_bpo_area() { AreaID = r.ID, basic_ID = basis_detail_id });
                if (BpoArea.Count > 0)
                {
                    db.dev_bpo_area.AddRange(bpo_Areas);
                    db.SaveChanges();
                }
                DevArea = model.DevArea.Where(x => x.Checked == true).ToList();
                List<dev_bpo_area> dev_area = new List<dev_bpo_area>();
                foreach (MultiCheckListBox r in DevArea)
                    dev_area.Add(new dev_bpo_area() { AreaID = r.ID, basic_ID = basis_detail_id });
                if (DevArea.Count > 0)
                {
                    db.dev_bpo_area.AddRange(dev_area);
                    db.SaveChanges();
                }

            }
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            employee_detail model = new employee_detail();
            var skills = db.skills.ToList();
            model.basic_id = int.Parse(Request["basicid"]);
            ViewBag.Skills = new SelectList(skills, "skill_id", "skill_name");
            ViewBag.DesignationID = new SelectList(db.positions.ToList(), "position_id", "position_title");
            return View(model);
        }
        [HttpPost]
        public JsonResult AddEmployee(employee_detail model, int[] Skills)
        {
            if (ModelState.IsValid)
            {
                db.employee_detail.Add(model);
                db.SaveChanges();
            }
            int id = model.employee_id;
            if (Skills != null && Skills.Length > 0)
            {
                List<employee_skills> lstSkills = new List<employee_skills>();
                foreach (int sk in Skills)
                {
                    lstSkills.Add(new employee_skills() { employee_id = id, skill_id = sk });
                }
                db.employee_skills.AddRange(lstSkills);
                db.SaveChanges();
            }
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DisplayEmployee(int companyid)
        {
            var emps = db.employee_detail.Where(x => x.employee_id == companyid).ToList();
            return PartialView("~/Views/registration/_DisplayEmployee.cshtml", emps);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var sk = db.employee_skills.Where(x => x.employee_id == id).ToList();
            db.employee_skills.RemoveRange(sk);
            db.SaveChanges();
            var emp = db.employee_detail.Where(x => x.employee_id == id).FirstOrDefault();
            db.employee_detail.Remove(emp);
            db.SaveChanges();
            return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
        }
        // public ActionResult Create(registration_vm registration, List<employees_vm> employees, List<dev_bpo_vm> devareas)
        //public ActionResult Create(registration_mvvm mvvm)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //basic details
        //    basic_detail details = new basic_detail();
        //    details.name = mvvm.registration.person_name;
        //    details.is_company = mvvm.registration.is_company;
        //    details.email_address = mvvm.registration.basic_email_address;
        //    details.mobile_number = mvvm.registration.basic_mobile_number;
        //    details.phone_number = mvvm.registration.basic_phone_number;
        //    details.country_id = mvvm.registration.basic_country_id;
        //    details.province_id = mvvm.registration.basic_province_id;
        //    details.district_id = mvvm.registration.basic_district_id;
        //    details.address = mvvm.registration.basic_address;
        //    details.other_details = mvvm.registration.basic_other_details;
        //    db.basic_detail.Add(details);
        //    int basic_detail_id = db.SaveChanges();
        //    // 
        //    if (mvvm.registration.is_company == 1)
        //    {
        //        // business detail
        //        business_detail business = new business_detail();
        //        // business.business_id = registration.business_id;
        //        business.basic_id = basic_detail_id;
        //        business.company_name = mvvm.registration.company_name;
        //        business.principal_country_id = mvvm.registration.principal_country_id;
        //        business.princiapal_province_id = mvvm.registration.princiapal_province_id;
        //        business.principal_distict_id = mvvm.registration.principal_distict_id;
        //        business.business_in_kp_district_id = mvvm.registration.business_in_kp_district_id;
        //        business.city_in_kp = mvvm.registration.city_in_kp;
        //        business.comapy_website = mvvm.registration.comapy_website;
        //        business.business_email = mvvm.registration.business_email;
        //        business.contact_person_name = mvvm.registration.contact_person_name;
        //        business.office_number = mvvm.registration.office_number;
        //        db.business_detail.Add(business);
        //        db.SaveChanges();

        //        //employees detail
        //        employees_detail emp;
        //        foreach (var employee in mvvm.employees_vm)
        //        {
        //            emp = new employees_detail();
        //            emp.basic_id = basic_detail_id;
        //            emp.position_id = employee.position_id;
        //            emp.number_of_hr = employee.number_of_hr;
        //            db.employees_detail.Add(emp);
        //        }
        //        // employee skills
        //        employee_skills skills;
        //        foreach (var skls in mvvm.emp_Skills)
        //        {
        //            skills = new employee_skills();
        //            skills.personnel_id = skls.personnel_id;
        //            skills.skill_id = skls.skill_id;
        //            db.employee_skills.Add(skills);
        //        }

        //        //development and bpo areas
        //        dev_bpo_area dev;
        //        foreach (var area in mvvm.dev_bpo_vm)
        //        {
        //            dev = new dev_bpo_area();
        //            dev.basic_ID = area.basic_id;
        //            dev.AreaID = area.area_id;
        //            db.dev_bpo_area.Add(dev);
        //        }

        //        db.SaveChanges();
        //        //  }

        //    }

        //    return View();
        //    // return View(basic_detail);
        //}

        //// GET: registration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            basic_detail model = db.basic_detail.Find(id);
            ViewBag.is_company = new SelectList(Dropdowns.Company, "Value", "Text",model.is_company);
            ViewBag.country_id = new SelectList(db.countries.ToList(), "country_id", "country_name",model.country_id);
            ViewBag.province_id = new SelectList(db.provinces.ToList(), "province_id", "province_name",model.province_id);
            ViewBag.district_id = new SelectList(db.districts.ToList(), "district_id", "district_name",model.district_id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: registration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "basic_id,name,is_company,email_address,mobile_number,phone_number,country_id,province_id,district_id,address,other_details")] basic_detail basic_detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basic_detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(basic_detail);
        }

        //// GET: registration/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    basic_detail basic_detail = db.basic_detail.Find(id);
        //    if (basic_detail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(basic_detail);
        //}

        //// POST: registration/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    basic_detail basic_detail = db.basic_detail.Find(id);
        //    db.basic_detail.Remove(basic_detail);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
