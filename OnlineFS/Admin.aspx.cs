using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
  Database database;
  Validate validate;
  string Role = "";
    protected void Page_Load(object sender, EventArgs e)
    {
      validate = new Validate();
      database = new Database();
    }
    protected void Adminfu(object sender, EventArgs e)
    {
        /*string User = username.Text;
        string pass = password.Text;
        if(username.Text != "" && password.Text != "")
        {
            if (User == "administrator" && pass == "Welcome@123")
            {
                status.Text = "Successfully login";
            }
            else
            {
                status.Text = "Invalid username and password";
            }
        }*/
        string UserName = username.Text;
        string Password = password.Text;
        Role = validate.GetRole(UserName, Password);
        if(Role == "admin")
        {
          Session["UserName"] = username.Text;
          Session["Pwd"] = password.Text;
          Response.Redirect("adminindex.aspx?user=1");

        }
        // else// if(Role == "Please Register")
        // {
        //     status.Text = "Please Register";
        // }
    }
}
