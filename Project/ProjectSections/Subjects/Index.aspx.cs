using Project.Database;
using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.ProjectSections.Subjects
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
        protected string PopulateTable()
        {
            using (var dbContext = new ProjectDbContext())
            {
                int FPId = string.IsNullOrEmpty(FProfessorId.SelectedValue) ? 0 : Convert.ToInt32(FProfessorId.SelectedValue);
                var entities = dbContext.Subjects
                    .Include("Professor")
                    .Where(a => string.IsNullOrEmpty(FProfessorId.SelectedValue) || a.ProfessorId == FPId)
                    .Where(a => string.IsNullOrEmpty(FName.Value) || a.Name.ToLower().Contains(FName.Value.ToLower()))
                    .ToList();
                string tableRows = string.Empty;
                foreach (var item in entities)
                {
                    string name = item.Name;
                    string professor = item.Professor.Name;
                    string editUrl = ResolveUrl("Edit?code=" + item.Code);
                    string deleteUrl = ResolveUrl("Delete?code=" + item.Code);

                    tableRows += $"<tr>" +
                                 $"<td>{name}</td>" +
                                 $"<td>{professor}</td>" +
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