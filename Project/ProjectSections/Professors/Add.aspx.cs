using Project.Database;
using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Project.ProjectSections.Professors
{
    public partial class Add : System.Web.UI.Page
    {
        public List<ScientificRank> ScientificRanks { get;set; }
        protected async void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                using (var dbContext = new ProjectDbContext())
                {
                    ScientificRanks = await dbContext.ScientificRanks.ToListAsync();
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
                    var entity = new Professor();
                    entity.Name = Request.Form["Name"];
                    entity.ScientificRankCode = Convert.ToInt32(Request.Form["ScientificRankCode"]);
                    dbContext.Professor.Add(entity);
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