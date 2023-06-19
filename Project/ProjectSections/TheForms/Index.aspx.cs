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

namespace Project.ProjectSections.TheForms
{
    public partial class Index : System.Web.UI.Page
    {
        public decimal TotalHours { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public decimal TotalNotPaidAmount { get; set; }
        public decimal TotalSubject { get; set; }
        public decimal TotalPaidSubject { get; set; }
        public decimal TotalNotPaidSubject { get; set; }

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
        protected async void PopulateLecturePricesDropDownList()
        {
            using (var dbContext = new ProjectDbContext())
            {
                var lecturePrices = await dbContext.LectureHours.ToListAsync();
                FLecturePriceId.Items.Clear();
                FLecturePriceId.Items.Add(new ListItem("Select...", ""));
                foreach (var item in lecturePrices)
                    FLecturePriceId.Items.Add(new ListItem(item.Title, item.Id.ToString()));
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
                int fLecturePriceId = string.IsNullOrEmpty(FLecturePriceId.SelectedValue) ? 0 : Convert.ToInt32(FLecturePriceId.SelectedValue);
                bool? fIsPaid = !FUseIsPaidFilter.Checked ? null : (bool?)FIsPaid.Checked;
                var entities = dbContext.TheForms
                    .Include("Professor")
                    .Include("Subject")
                    .Include("ScientificRank")
                    .Include("LectureHours")
                    .Where(a => string.IsNullOrEmpty(FProfessorId.SelectedValue) || a.ProfessorId == FPId)
                    .Where(a => string.IsNullOrEmpty(FScientificRankCode.SelectedValue) || a.ScientificRankCode == FSRCode)
                    .Where(a => string.IsNullOrEmpty(FSubjectCode.SelectedValue) || a.SubjectCode == FSCode)
                    .Where(a => fromDate == null || a.FormDate >= fromDate)
                    .Where(a => toDate == null || a.FormDate <= toDate)
                    .Where(a => string.IsNullOrEmpty(FLecturePriceId.SelectedValue) || a.LectureHoursId == fLecturePriceId)
                    .Where(a => fIsPaid== null || a.IsPaied == fIsPaid)
                    .ToList();

                TotalHours = entities.Sum(a => a.NumberOfHours);
                TotalAmount = entities.Sum(a => a.Price *a.NumberOfHours );
                TotalPaidAmount = entities.Where(a=>a.IsPaied).Sum(a => a.Price * a.NumberOfHours);
                TotalNotPaidAmount = entities.Where(a=>!a.IsPaied).Sum(a => a.Price * a.NumberOfHours);
                TotalSubject = entities.Count;
                TotalPaidSubject = entities.Where(a=>a.IsPaied).Count();
                TotalNotPaidSubject = entities.Where(a => !a.IsPaied).Count();


                string tableRows = string.Empty;
                foreach (var item in entities)
                {

                    string professor = item.Professor.Name;
                    string scientificRank = item.ScientificRank.Title;
                    string subject = item.Subject.Name;
                    string formDate = item.FormDate.Date.ToString("yyyy/MM/dd");
                    string lecturePrice = item.LectureHours.Title;
                    string price = item.Price.ToString();
                    string numberOfHours = item.NumberOfHours.ToString();
                    string amount = (item.Price* item.NumberOfHours).ToString();
                    string isPaid = item.IsPaied ? "Paid" : "Not Paid";
                    string isPaidUrl = ResolveUrl("Pay?id=" + item.Id);
                    string editUrl = ResolveUrl("Edit?id=" + item.Id);
                    string deleteUrl = ResolveUrl("Delete?id=" + item.Id);

                    tableRows += $"<tr>" +
                                 $"<td>{professor}</td>" +
                                 $"<td>{scientificRank}</td>" +
                                 $"<td>{subject}</td>" +
                                 $"<td>{formDate}</td>" +
                                 $"<td>{lecturePrice}</td>" +
                                 $"<td>{price}</td>" +
                                 $"<td>{numberOfHours}</td>" +
                                 $"<td>{amount}</td>" +
                                 $"<td><a href='{isPaidUrl}' >{isPaid}</a></td>" +
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
                    PopulateLecturePricesDropDownList();
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