﻿using Project.Database;
using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.ProjectSections.Professors
{
    public partial class Delete : System.Web.UI.Page
    {
        public Professor Entity { get; set; }
        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(Request.QueryString["id"]))
                    throw new Exception("this row not found");
                int id = Convert.ToInt32(Request.QueryString["id"]);
                using(var dbContext = new ProjectDbContext())
                {
                    Entity = await dbContext.Professor.Include("ScientificRank").Where(a => a.Id == id).FirstOrDefaultAsync();

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
                var dbContext = new ProjectDbContext();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                var entity = await dbContext.Professor.FindAsync(id);
                _ = dbContext.Professor.Remove(entity);
                await dbContext.SaveChangesAsync();
                Response.Redirect("Index");
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