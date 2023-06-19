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
    public partial class Add : System.Web.UI.Page
    {
        public List<Professor> Professors { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<ScientificRank> ScientificRanks { get; set; }
        public List<LectureHours> LecturePrices { get; set; }

        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new ProjectDbContext())
                {
                    Professors = await dbContext.Professor.ToListAsync();
                    Subjects = await dbContext.Subjects.ToListAsync();
                    ScientificRanks = await dbContext.ScientificRanks.ToListAsync();
                    LecturePrices = await dbContext.LectureHours.ToListAsync();
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
                    var entity = new TheForm();
                    entity.SubjectCode =Convert.ToInt32( Request.Form["SubjectCode"]);
                    entity.ProfessorId = Convert.ToInt32(Request.Form["ProfessorId"]);
                    entity.ScientificRankCode = Convert.ToInt32(Request.Form["ScientificRankCode"]);
                    entity.FormDate = DateTimeOffset.Parse( Request.Form["FormDate"]);
                    entity.LectureHoursId = Convert.ToInt32(Request.Form["LecturePriceId"]);
                    var lecturePrice = await dbContext.LectureHours.Where(a=>a.Id == entity.LectureHoursId).FirstOrDefaultAsync();
                    var scientificRanks = await dbContext.ScientificRanks.Where(a => a.Code == entity.ScientificRankCode).FirstOrDefaultAsync();

            
                    entity.Price = scientificRanks.Price;
                    entity.NumberOfHours = lecturePrice.NumberOfHours;
                    entity.IsPaied = false;

                    dbContext.TheForms.Add(entity);
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