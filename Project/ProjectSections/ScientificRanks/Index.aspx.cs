using Project.Database;
using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Project.ProjectSections.ScientificRanks
{
    public partial class Index : System.Web.UI.Page
    {
        protected string PopulateTable()
        {
            using (var dbContext = new ProjectDbContext())
            {
                var entities = dbContext.ScientificRanks
                         .Where(a => string.IsNullOrEmpty(FTitle.Value) || a.Title.ToLower().Contains(FTitle.Value.ToLower()))
                         .Where(a => string.IsNullOrEmpty(FDescription.Value) || a.Description.ToLower().Contains(FDescription.Value.ToLower()))
                         .ToList();
                string tableRows = string.Empty;
                foreach (var item in entities)
                {
                    string title = item.Title;
                    string description = item.Description;
                    string editUrl = ResolveUrl("Edit?code=" + item.Code);
                    string deleteUrl = ResolveUrl("Delete?code=" + item.Code);

                    tableRows += $"<tr>" +
                                 $"<td>{title}</td>" +
                                 $"<td>{description}</td>" +
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