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
    public partial class Edit : System.Web.UI.Page
    {
        public TheForm Entity { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Professor> Professors { get; set; }
        public List<ScientificRank> ScientificRanks { get; set; }
        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new ProjectDbContext())
                {
                    Subjects = await dbContext.Subjects.ToListAsync();
                    Professors = await dbContext.Professor.ToListAsync();
                    ScientificRanks = await dbContext.ScientificRanks.ToListAsync();
                    if (string.IsNullOrEmpty(Request.QueryString["id"]))
                        throw new Exception("this row not found");
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Entity = await dbContext.TheForms.Include("Subject")
                                                     .Include("Professor")
                                                     .Include("ScientificRank").Where(a => a.Id == id).FirstOrDefaultAsync();
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
                    var entity = await dbContext.TheForms.FindAsync(id);
                    entity.FormDate = DateTimeOffset.Parse(Request.Form["FormDate"]);
                    entity.SubjectCode = Convert.ToInt32(Request.Form["SubjectCode"]);
                    entity.ProfessorId = Convert.ToInt32(Request.Form["ProfessorId"]);
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