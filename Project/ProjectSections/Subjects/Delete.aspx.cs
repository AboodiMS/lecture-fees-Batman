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
    public partial class Delete : System.Web.UI.Page
    {
        public Subject Entity { get; set; }
        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Request.QueryString["code"]))
                    throw new Exception("this row not found");
                int code = Convert.ToInt32(Request.QueryString["code"]);
                using (var dbContext = new ProjectDbContext())
                {
                    Entity = await dbContext.Subjects.Include("Professor").Where(a => a.Code == code).FirstOrDefaultAsync();

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
                int code = Convert.ToInt32(Request.QueryString["code"]);
                var entity = await dbContext.Subjects.FindAsync(code);
                _ = dbContext.Subjects.Remove(entity);
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