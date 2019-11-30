using Microsoft.AspNetCore.Mvc;
using System;
using soe_backend.Models;

namespace soe_backend.Controllers
{
    [Route("api/[controller]")]
    public class SoeFormController : Controller
    {
        [HttpGet]
        public string GetForm()
        {
            string sqlResult = "";
            try
            {
                sqlResult = SQLHandler.ExecuteQuery("SELECT * FROM dbo.forms");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return "Unable to execute query: " + ex;
            }
            return sqlResult;
        }

        [HttpPost]
        public string PostFormData([FromBody] FormData form)
        {
            string sqlResult = "";
            string query = String.Format("INSERT INTO forms VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20});",
                                        "'" + form.project_id + "'",
                                        "'" + form.project_title + "'",
                                        "'" + form.deadline + "'",
                                        "'" + form.pi_name + "'",
                                        "'" + form.pi_email + "'",
                                        "'" + form.sponsor_name + "'",
                                        "'" + form.proposal_url + "'",
                                        "'" + form.preferred_submission + "'",
                                        "'" + form.opportunity_number + "'",
                                        "'" + form.nsf_proposal_number + "'",
                                        "'" + form.nsf_pin_number + "'",
                                        "'" + form.project_start + "'",
                                        "'" + form.project_end + "'",
                                        form.estimated_budget,
                                        "'" + form.budget_items + "'",
                                        form.extra_space,
                                        "'" + form.space_details + "'",
                                        form.course_buyout,
                                        "'" + form.buyout_details + "'",
                                        "'" + form.applicant_role + "'",
                                        "'" + form.additional_info + "'"
                                        );
            try
            {
                sqlResult = SQLHandler.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return sqlResult;
        }
    }
}