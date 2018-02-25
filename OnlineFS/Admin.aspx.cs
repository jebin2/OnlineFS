using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Adminfu(object sender, EventArgs e)
    {
        string User = username.Text;
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
        }

    }
}