using Project.Database;
using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Project.ProjectSections.Professors
{
    public partial class Index : System.Web.UI.Page
    {
        protected async void PopulateScientificRanksDropDownList()
        {
            using (var dbContext = new ProjectDbContext())
            {
                var scientificRanks = await dbContext.ScientificRanks.ToListAsync();
                FScientificRankCode.Items.Clear();
                FScientificRankCode.Items.Add(new ListItem("Select...", ""));
                foreach (var item in scientificRanks)
                    FScientificRankCode.Items.Add(new ListItem(item.Title,item.Code.ToString()));
            }

        }
        protected string PopulateTable()
        {
            using (var dbContext = new ProjectDbContext())
            {
                int FSRCode = string.IsNullOrEmpty(FScientificRankCode.SelectedValue) ? 0 : Convert.ToInt32(FScientificRankCode.SelectedValue);
                var entities =  dbContext.Professor
                    .Include("ScientificRank")
                    .Where(a=> string.IsNullOrEmpty(FScientificRankCode.SelectedValue) ||  a.ScientificRankCode == FSRCode)
                    .Where(a => string.IsNullOrEmpty(FName.Value) || a.Name.ToLower().Contains(FName.Value.ToLower()))
                    .ToList();
                string tableRows = string.Empty;
                foreach (var item in entities)
                {
                    string name = item.Name;
                    string scientificRank = item.ScientificRank.Title;
                    string editUrl = ResolveUrl("Edit?id=" + item.Id);
                    string deleteUrl = ResolveUrl("Delete?id=" + item.Id);

                    tableRows += $"<tr>" +
                                 $"<td>{name}</td>" +
                                 $"<td>{scientificRank}</td>" +
                                 $"<td><a href='{editUrl}'  class=\"btn btn-secondary\">Edit</a></td>" +
                                 $"<td><a href='{deleteUrl}'  class=\"btn btn-danger\">Delete</a></td>" +
                                 $"</tr>";
                }

                return tableRows;
            }
        }

        protected   void Page_Load(object sender, EventArgs e)
        {
           
            try
            {          
                if (!IsPostBack)
                {             
                    PopulateScientificRanksDropDownList();
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