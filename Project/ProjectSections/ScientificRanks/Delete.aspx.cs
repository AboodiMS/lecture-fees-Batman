using Project.Database;
using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.ProjectSections.ScientificRanks
{
    public partial class Delete : System.Web.UI.Page
    {
        public ScientificRank Entity { get; set; }
        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Request.QueryString["code"]))
                    throw new Exception("this row not found");
                int code = Convert.ToInt32(Request.QueryString["code"]);
                using (var dbContext = new ProjectDbContext())
                {
                    Entity = await dbContext.ScientificRanks.Where(a => a.Code == code).FirstOrDefaultAsync();
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
                using (var dbContext = new ProjectDbContext())
                {
                    int code = Convert.ToInt32(Request.QueryString["code"]);
                    var entity = await dbContext.ScientificRanks.FindAsync(code);
                    _ = dbContext.ScientificRanks.Remove(entity);
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