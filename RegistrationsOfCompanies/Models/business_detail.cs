//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegistrationsOfCompanies.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class business_detail
    {
        public int business_id { get; set; }
        public int basic_id { get; set; }
        public Nullable<int> principal_country_id { get; set; }
        public Nullable<int> princiapal_province_id { get; set; }
        public Nullable<int> principal_distict_id { get; set; }
        public int business_in_kp_district_id { get; set; }
        public int city_in_kp { get; set; }
        public string company_name { get; set; }
        public string comapy_website { get; set; }
        public string business_email { get; set; }
        public string contact_person_name { get; set; }
        public string office_number { get; set; }
        public Nullable<decimal> annual_turnover { get; set; }
        public string principal_address { get; set; }
        public string regional_office_address { get; set; }
        public Nullable<System.DateTime> operational_since { get; set; }
        public string registration_with { get; set; }
        public string registration_with_pseb { get; set; }
        public string company_short_description { get; set; }
        public Nullable<int> no_of_employees { get; set; }
        public string hardware_info { get; set; }
        public string other_service_detail { get; set; }
        public string company_logo { get; set; }
        public string company_Tagline { get; set; }
    
        public virtual basic_detail basic_detail { get; set; }
        public virtual city city { get; set; }
        public virtual country country { get; set; }
        public virtual district district { get; set; }
        public virtual province province { get; set; }
    }
}
