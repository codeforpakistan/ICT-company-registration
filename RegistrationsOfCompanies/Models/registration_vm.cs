using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistrationsOfCompanies.Models
{
    public class registration_vm
    {
        //basic details
        public int basic_id { get; set; }
        [Required(ErrorMessage ="Field is required")]
        [Display(Name = "Name")]
        public string person_name { get; set; }
        [Display(Name = "Company/Individual/Freelancer")]
        public int is_company { get; set; }
      
        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Email Address ")]
        [EmailAddress]
        public string basic_email_address { get; set; }
        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Mobile Number")]
        public string basic_mobile_number { get; set; }
        [Display(Name = "Phone Number")]
        public string basic_phone_number { get; set; }
        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Country")]
        public int basic_country_id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Province")]
        public int basic_province_id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "District")]
        public int basic_district_id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Address")]
        public string basic_address { get; set; }
        [Display(Name = "Other Details")]
        public string basic_other_details { get; set; }

        //business detail
        public int business_id { get; set; }
        
        [Display(Name = "Company Name")]
        public string company_name { get; set; }
        [Display(Name = "Principal Country")]
        public int principal_country_id { get; set; }
        [Display(Name = "Principal Province ")]
        public int principal_province_id { get; set; }
        [Display(Name = "Principal Distict")]
        public int principal_district_id { get; set; }
        [Display(Name = "Business office in KP")]
        public int business_in_kp_district_id { get; set; }
        [Display(Name = "City")]
        public int city_in_kp { get; set; }
        [RegularExpression(@"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$",
         ErrorMessage = "Enter valid URL")]
        [Display(Name = "Company Website")]
        public string comapy_website { get; set; }
        [Display(Name = "Business Email ")]
        [EmailAddress]
        public string business_email { get; set; }
        [Display(Name = "Point of Contact")]
        public string contact_person_name { get; set; }
        [Display(Name = "Office Number")]
        public string office_number { get; set; }
        [Display(Name = "Annual Turnover")]
        public decimal? annual_turnover { get; set; }
        [Display(Name = "Principal Address")]
        public string principal_address { get; set; }
        [Display(Name = "Regional Office Address")]
        public string regional_office_address { get; set; }
        [Display(Name = "Operational Since")]
        public DateTime? operational_since { get; set; }
        [Display(Name = "Registration With")]
        public string registration_with { get; set; }
        [Display(Name = "Registration With PSEB")]
        public string registration_with_pseb { get; set; }
        [Display(Name = "Short Description")]
        public string company_short_description { get; set; }
        [Display(Name = "Number of Employees")]
        public int no_of_employees { get; set; }
        [Display(Name = "Hardware Information")]
        public string hardware_info { get; set; }
        [Display(Name = "Other Service Details")]
        public string other_service_detail { get; set; }
        public List<MultiCheckListBox> DevArea { get; set; }
        public List<MultiCheckListBox> BpoArea { get; set; }

        public List<MultiCheckListBox> ProductArea { get; set; }
        public List<employees_vm> Employee_vm { get; set; }
        public int designation_id { get; set; }
        public int empskills { get; set; }

        public Nullable<decimal> number_of_resources { get; set; }
    }

    public class employees_vm
    {
        //employee details
        public int employee_id { get; set; }
        public int basic_id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public int designation_id { get; set; }
        [Required(ErrorMessage ="Field is required")]
        [EmailAddress]
        public Nullable<decimal> number_of_resources { get; set; }
        public List<employee_skills_vm> skills_Vm { get; set; }

    }
    public class dev_bpo_vm
    {
        //development and bpo areas
        public int dev_bpo_area_id { get; set; }
        public int? basic_id { get; set; }
        public int? area_id { get; set; }
    }
    public class employee_skills_vm
    {
        //employee skills
        public int employee_skills_id { get; set; }
        public Nullable<int> employee_id { get; set; }
        public Nullable<int> skill_id { get; set; }
    }
}