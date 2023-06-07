using Project.Database.Entities;
using Project.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string username = Request.Form["userName"]; // Access the username entered
                string password = Request.Form["password"]; // Access the password entered

                if (username == "admin" && password == "admin")
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    errorContainer.InnerText = "Invalid username or password";
                    errorContainer.Style.Remove("display");

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