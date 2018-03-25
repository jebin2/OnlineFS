using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PostData : System.Web.UI.Page
{
    string UserName = "";
    string Password = "";
    Validate validate;

    protected void Page_Load(object sender, EventArgs e)
    {
        validate = new Validate();
        /*string UserName = Session["UserName"].ToString();
        string Password = Session["Pwd"].ToString();
        if (validate.GetRole(UserName, Password) != "Karomi")
        {
            Response.Redirect("Exit.aspx");
        }
        else
        {

        }*/
    }

    protected void Submit(object sender, EventArgs e)
    {
        content.PostedFile.SaveAs(@"c:\Users\Jebin\source\repos\OnlineFS\Upload\"+content.FileName);
    }

    protected void Logout(object sender, EventArgs e)
    {
        Session["UserName"] = "";
        Session["Pwd"] = "";
        Response.Redirect("Default.aspx");
    }
}
