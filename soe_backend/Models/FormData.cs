using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soe_backend.Models
{
    public class FormData
    {
        public string project_id { get; set; }
        public string project_title { get; set; }
        public string deadline { get; set; }
        public string pi_name { get; set; }
        public string pi_email { get; set; }
        public string sponsor_name { get; set; }
        public string proposal_url { get; set; }
        public string preferred_submission { get; set; }
        public string opportunity_number { get; set; }
        public string nsf_proposal_number { get; set; }
        public string nsf_pin_number { get; set; }
        public string project_start { get; set; }
        public string project_end { get; set; }
        public int estimated_budget { get; set; }
        public string budget_items { get; set; }
        public int extra_space { get; set; }
        public string space_details { get; set; }
        public int course_buyout { get; set; }
        public string buyout_details { get; set; }
        public string applicant_role { get; set; }
        public string additional_info { get; set; }
    }
}
