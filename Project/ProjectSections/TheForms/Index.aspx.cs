using Project.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Project.ProjectSections.TheForms
{
    public partial class Index : System.Web.UI.Page
    {
        protected async void PopulateProfessorsDropDownList()
        {
            using (var dbContext = new ProjectDbContext())
            {
                var professors = await dbContext.Professor.ToListAsync();
                FProfessorId.Items.Clear();
                FProfessorId.Items.Add(new ListItem("Select...", ""));
                foreach (var item in professors)
                    FProfessorId.Items.Add(new ListItem(item.Name, item.Id.ToString()));
            }
        }
        protected async void PopulateScientificRanksDropDownList()
        {
            using (var dbContext = new ProjectDbContext())
            {
                var scientificRanks = await dbContext.ScientificRanks.ToListAsync();
                FScientificRankCode.Items.Clear();
                FScientificRankCode.Items.Add(new ListItem("Select...", ""));
                foreach (var item in scientificRanks)
                    FScientificRankCode.Items.Add(new ListItem(item.Title, item.Code.ToString()));
            }

        }
        protected async void PopulateSubjectsDropDownList()
        {
            using (var dbContext = new ProjectDbContext())
            {
                var subjects = await dbContext.Subjects.ToListAsync();
                FSubjectCode.Items.Clear();
                FSubjectCode.Items.Add(new ListItem("Select...", ""));
                foreach (var item in subjects)
                    FSubjectCode.Items.Add(new ListItem(item.Name, item.Code.ToString()));
            }

        }
        protected string PopulateTable()
        {
            using (var dbContext = new ProjectDbContext())
            {
                int FPId = string.IsNullOrEmpty(FProfessorId.SelectedValue) ? 0 : Convert.ToInt32(FProfessorId.SelectedValue);
                int FSRCode = string.IsNullOrEmpty(FScientificRankCode.SelectedValue) ? 0 : Convert.ToInt32(FScientificRankCode.SelectedValue);
                int FSCode = string.IsNullOrEmpty(FSubjectCode.SelectedValue) ? 0 : Convert.ToInt32(FSubjectCode.SelectedValue);

                DateTimeOffset? fromDate = string.IsNullOrEmpty(FFromFormDate.Value)?null:(DateTimeOffset?) DateTimeOffset.Parse(FFromFormDate.Value);
                DateTimeOffset? toDate = string.IsNullOrEmpty(FToFormDate.Value) ? null : (DateTimeOffset?)DateTimeOffset.Parse(FToFormDate.Value);

                var entities = dbContext.TheForms
                    .Include("Professor")
                    .Include("Subject")
                    .Include("ScientificRank")
                    .Where(a => string.IsNullOrEmpty(FProfessorId.SelectedValue) || a.ProfessorId == FPId)
                    .Where(a => string.IsNullOrEmpty(FScientificRankCode.SelectedValue) || a.ScientificRankCode == FSRCode)
                    .Where(a => string.IsNullOrEmpty(FSubjectCode.SelectedValue) || a.SubjectCode == FSCode)
                    .Where(a => fromDate == null || a.FormDate >= fromDate)
                    .Where(a => toDate == null || a.FormDate <= toDate)
                    .ToList();
                string tableRows = string.Empty;
                foreach (var item in entities)
                {

                    string professor = item.Professor.Name;
                    string scientificRank = item.ScientificRank.Title;
                    string subject = item.Subject.Name;
                    string formDate = item.FormDate.Date.ToString("yyyy/MM/dd");
                    string editUrl = ResolveUrl("Edit?id=" + item.Id);
                    string deleteUrl = ResolveUrl("Delete?id=" + item.Id);

                    tableRows += $"<tr>" +
                                 $"<td>{professor}</td>" +
                                 $"<td>{scientificRank}</td>" +
                                 $"<td>{subject}</td>" +
                                 $"<td>{formDate}</td>" +
                                 $"<td><a href='{editUrl}'  class=\"btn btn-secondary\">Edit</a></td>" +
                                 $"<td><a href='{deleteUrl}'  class=\"btn btn-danger\">Delete</a></td>" +
                                 $"</tr>";
                }

                return tableRows;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    PopulateProfessorsDropDownList();
                    PopulateScientificRanksDropDownList();
                    PopulateSubjectsDropDownList();
                    PopulateTable();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred: " + ex.Message;
                errorContainer.InnerText = errorMessage;
                errorContainer.Style.Remove("display");
            }
        }
        protected void FilterButton_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateTable();
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