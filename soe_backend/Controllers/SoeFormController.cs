using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace soe_backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
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
                return "Unable to get form: " + ex;
            }
            return sqlResult;
        }

        [HttpPost]
        public async Task<string> PostFormData()
        {
            string sqlResult = "";

            using (var reader = new StreamReader(Request.Body))
            {
                dynamic form = Newtonsoft.Json.JsonConvert.DeserializeObject(await reader.ReadToEndAsync());

                string query = String.Format("INSERT INTO forms VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}');",
                                            form.project_id,
                                            form.project_title,
                                            form.deadline,
                                            form.pi_name,
                                            form.pi_email,
                                            form.sponsor_name,
                                            form.proposal_url,
                                            form.preferred_submission,
                                            form.opportunity_number,
                                            form.nsf_proposal_number,
                                            form.nsf_pin_number,
                                            form.project_start,
                                            form.project_end,
                                            form.estimated_budget,
                                            form.budget_items,
                                            form.extra_space,
                                            form.space_details,
                                            form.course_buyout,
                                            form.buyout_details,
                                            form.applicant_role,
                                            form.additional_info
                                            );
                try
                {
                    sqlResult = SQLHandler.ExecuteQuery(query);
                }
                catch (Exception ex)
                {
                    return "Error storing form:" + ex;
                }
            }
            return sqlResult;
        }
    }
}