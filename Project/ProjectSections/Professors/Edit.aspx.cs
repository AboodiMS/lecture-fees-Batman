using Project.Database;
using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.ProjectSections.Professors
{
    public partial class Edit : System.Web.UI.Page
    {
        public Professor Entity { get; set; }
        public List<ScientificRank> ScientificRanks { get; set; }

        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using(var dbContext = new ProjectDbContext())
                {
                    ScientificRanks = await dbContext.ScientificRanks.ToListAsync();
                    if (string.IsNullOrEmpty(Request.QueryString["id"]))
                        throw new Exception("this row not found");
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Entity = await dbContext.Professor.Include("ScientificRank").Where(a => a.Id == id).FirstOrDefaultAsync();
                    if (Entity == null)
                        throw new Exception("this row not found");
                }

            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred: " + ex.Message;
                errorContainer.InnerText = errorMessage;
                errorContainer.Style.Remove("display");
            }
        }
        protected async void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                using(var dbContext = new ProjectDbContext())
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    var entity = await dbContext.Professor.FindAsync(id);
                    entity.Name = Request.Form["Name"];
                    entity.ScientificRankCode = Convert.ToInt32(Request.Form["ScientificRankCode"]);
                    await dbContext.SaveChangesAsync();
                    Response.Redirect("Index");
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred: " + ex.Message;
                errorContainer.InnerText = errorMessage;
                errorContainer.Style.Remove("display");
            }

        }
    }
}