using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Index : System.Web.UI.Page
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

    }

    protected void SearchButton(object sender, EventArgs e){
      string Search = search.Text;
      string[] Output = new string[]{"title,","username,","cost",",keyword"};
      string Table = "info";
      string Condition = " where keyword like '%"+Search+"%' or title like '%"+Search+"%' order by cost DESC";
      database.open();
      /*string yourDataItems = "<div class='card mb-4'><img class='card-img-top' src='http://placehold.it//750x300' alt='Card image cap'><div class='card-body'><h2 class='card-title' runat='server' ID='cardtitle1'>Post Title</h2><p class='card-text'>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p><a href='#' class='btn btn-primary'>Read More &rarr;</a></div><div class='card-footer text-muted'>Posted on January 1, 2017 by<a href='#'>Start Bootstrap</a></div></div>";
      rptItems.DataSource = yourDataItems;
      rptItems.DataBind();*/
      SqlDataReader sqlDataReader = database.SelectQuery(Output,Table,Condition);
      if(sqlDataReader.HasRows){
        sqlDataReader.Read();
        displaydata(sqlDataReader.GetString(0).ToString(),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(3).ToString());
      }
    }

    protected void displaydata(string title, string username,string content){
      HtmlGenericControl myDiv = new HtmlGenericControl("div");
            myDiv.ID = "myDiv";
            myDiv.Attributes["class"] = "card mb-4";
            /*LinkButton myLnkBtn = new LinkButton();
            myLnkBtn.ID = "myLnkBtn";
            myLnkBtn.Click += new EventHandler(myLnkBtn_Click);
            myLnkBtn.Text = "I'm dynamic";
            myDiv.Controls.Add(myLnkBtn);*/
      HtmlGenericControl myDiv1 = new HtmlGenericControl("div");
            myDiv1.ID = "myDiv1";
            myDiv1.Attributes["class"] = "card-img-top";

      HtmlGenericControl myDiv2 = new HtmlGenericControl("div");
            myDiv2.ID = "myDiv2";
            myDiv2.Attributes["class"] = "card-body";

      HtmlGenericControl myH2 = new HtmlGenericControl("h2");
            myH2.ID = "cardtitle1";
            myH2.Attributes["class"] = "card-title";
            myH2.InnerHtml = title;
            myDiv2.Controls.Add(myH2);

      HtmlGenericControl myp = new HtmlGenericControl("p");
            myp.ID = "cardtitle1";
            myp.Attributes["class"] = "card-text";
            myp.InnerHtml = content;
            myDiv2.Controls.Add(myp);

      HtmlGenericControl mya = new HtmlGenericControl("a");
            mya.ID = "mya1";
            mya.Attributes["href"] = "#";
            mya.Attributes["class"] = "btn btn-primary";
            mya.InnerHtml = "Read More &rarr;";
            myDiv2.Controls.Add(mya);

            myDiv1.Controls.Add(myDiv2);

            HtmlGenericControl myDiv3 = new HtmlGenericControl("div");
                  myDiv3.ID = "myDiv3";
                  myDiv3.Attributes["class"] = "card-footer text-muted";
                  myDiv3.InnerHtml = username;
            HtmlGenericControl mya1 = new HtmlGenericControl("a");
                  mya1.ID = "mya11";
                  mya1.Attributes["href"] = "#";
                  mya1.InnerHtml = "Start Bootstrap";
                  myDiv3.Controls.Add(mya1);

            myDiv1.Controls.Add(myDiv3);
            myDiv.Controls.Add(myDiv1);
            PlaceHolder1.Controls.Add(myDiv);
    }

    void myLnkBtn_Click(object sender, EventArgs e)
        {
            Response.Write(DateTime.Now.ToString());
        }
}
