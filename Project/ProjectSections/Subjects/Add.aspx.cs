using Project.Database.Entities;
using Project.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Project.ProjectSections.Subjects
{
    public partial class Add : System.Web.UI.Page
    {
        public List<Professor> Professors { get; set; }
        protected async void Page_Load(object sender, EventArgs e)
        {

            try
            {
                using (var dbContext = new ProjectDbContext())
                {
                    Professors = await dbContext.Professor.ToListAsync();
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
                    var entity = new Subject();
                    entity.Name = Request.Form["Name"];
                    entity.ProfessorId = Convert.ToInt32(Request.Form["ProfessorId"]);
                    dbContext.Subjects.Add(entity);
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