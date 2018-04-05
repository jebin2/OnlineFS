using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class post : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
      // postlogout.Visible = false;
    }

    protected void fLogout(object sender, EventArgs e){
       Session["UserName"] = "";
       Session["Pwd"] = "";
       Response.Redirect("default.aspx");
    }
}
