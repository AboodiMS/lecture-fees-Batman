using Project.Database.Entities;
using Project.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Project.ProjectSections.TheForms
{
    public partial class Delete : System.Web.UI.Page
    {
        public TheForm Entity { get; set; }
        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Request.QueryString["id"]))
                    throw new Exception("this row not found");
                int id = Convert.ToInt32(Request.QueryString["id"]);
                using (var dbContext = new ProjectDbContext())
                {
                    Entity = await dbContext.TheForms
                                            .Include("Professor")
                                            .Include("Subject")
                                            .Include("ScientificRank")
                                            .Where(a => a.Id == id).FirstOrDefaultAsync();

                }
                if (Entity == null)
                    throw new Exception("this row not found");
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
                var dbContext = new ProjectDbContext();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                var entity = await dbContext.TheForms.FindAsync(id);
                _ = dbContext.TheForms.Remove(entity);
                await dbContext.SaveChangesAsync();
                Response.Redirect("Index");
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