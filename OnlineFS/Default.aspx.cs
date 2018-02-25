using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    Validate validate;
    string Role = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        validate = new Validate();
    }

    protected void Login(object sender, EventArgs e)
    {
        string UserName = username.Text;
        string Password = password.Text;
        Role = validate.GetRole(UserName, Password);
        if (Role == "Karomi")
        {
            Session["UserName"] = username.Text;
            Session["Pwd"] = password.Text;
            Response.Redirect("PostData.aspx");
            //Server.Transfer("PostData.aspx");
        }
        else if(Role == "Client")
        {
            Session["UserName"] = username.Text;
            Session["Pwd"] = password.Text;
            Response.Redirect("PostTicket.aspx");
        }
        else if(Role == "Please Register")
        {
            status.Text = "Please Register";
        }
        else
        {
            status.Text = Role;
        }
    }
}