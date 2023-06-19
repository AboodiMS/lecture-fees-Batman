using Project.Database.Entities;
using Project.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.ProjectSections.LecturePrices
{
    public partial class Add : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
        }

        protected async void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new ProjectDbContext())
                {
                    var entity = new LectureHours();
                    entity.Title = Request.Form["Title"];
                    entity.NumberOfHours = Convert.ToDecimal(Request.Form["NumberOfHours"]);
                    dbContext.LectureHours.Add(entity);
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