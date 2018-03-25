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
    Database database;
    Validate validate;
    string Role = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        validate = new Validate();
        database = new Database();
    }

    protected void Login(object sender, EventArgs e)
    {
        string UserName = username.Text;
        string Password = password.Text;
        Role = validate.GetRole(UserName, Password);
        if (Role == "karomi")
        {
            Session["UserName"] = username.Text;
            Session["Pwd"] = password.Text;
            PostData.Visible = true;
            Response.Redirect("index.aspx?user=1");
            //Response.Redirect("PostData.aspx");
            //Server.Transfer("PostData.aspx");
        }
        else if(Role == "client")
        {
            Session["UserName"] = username.Text;
            Session["Pwd"] = password.Text;
            Response.Redirect("PostTicket.aspx?user=1");
        }
        else if(Role == "admin")
        {
          Session["UserName"] = username.Text;
          Session["Pwd"] = password.Text;
          Response.Redirect("adminindex.aspx?user=1");

        }
        else
        {
            status.Text = "Please Register";
        }
    }

    /*protected void SearchButton(object sender, EventArgs e){
      string Search = search.Text;
      string[] Output = new string[]{"id","title","username","cost"};
      string Table = "info";
      string Condition = " where keyword like '%"+Search+"%' or title like '%"+Search+"%' order by cost DESC";
      database.open();

      SqlDataReader sqlDataReader = database.SelectQuery(Output,Table,Condition);
      if(sqlDataReader.HasRows){
        sqlDataReader.Read();

      }
    }*/
}
