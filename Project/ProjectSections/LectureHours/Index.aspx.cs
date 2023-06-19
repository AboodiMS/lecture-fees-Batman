using Project.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Project.ProjectSections.LecturePrices
{
    public partial class index : System.Web.UI.Page
    {
        protected string PopulateTable()
        {
            using (var dbContext = new ProjectDbContext())
            {
                var entities = dbContext.LectureHours
                    .Where(a => string.IsNullOrEmpty(FTitle.Value) || a.Title.ToLower().Contains(FTitle.Value.ToLower()))
                    .ToList();
                string tableRows = string.Empty;
                foreach (var item in entities)
                {
                    string title = item.Title;
                    string numberOfHours = item.NumberOfHours.ToString();
                    string editUrl = ResolveUrl("Edit?id=" + item.Id);
                    string deleteUrl = ResolveUrl("Delete?id=" + item.Id);

                    tableRows += $"<tr>" +
                                 $"<td>{title}</td>" +
                                 $"<td>{numberOfHours}</td>" +
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