using Project.Database.Entities;
using Project.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Project.ProjectSections.LecturePrices
{
    public partial class Edit : System.Web.UI.Page
    {
        public LectureHours Entity { get; set; }

        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new ProjectDbContext())
                {
                    if (string.IsNullOrEmpty(Request.QueryString["id"]))
                        throw new Exception("this row not found");
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Entity = await dbContext.LectureHours.Where(a => a.Id == id).FirstOrDefaultAsync();
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
                using (var dbContext = new ProjectDbContext())
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    var entity = await dbContext.LectureHours.FindAsync(id);
                    entity.Title = Request.Form["Title"];
                    entity.NumberOfHours = Convert.ToDecimal(Request.Form["NumberOfHours"]);
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