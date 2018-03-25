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
    string GUID = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        validate = new Validate();
        database = new Database();
        string user = Request.QueryString["user"];
        if(user =="1"){
          login.Visible = false;
        }else{
          logout.Visible = false;
        }
        // if (validate.GetRole(UserName, Password) != "Karomi")
        // {
        //     Response.Redirect("Exit.aspx");
        // }
        //mya_mya();
        // if(Request["__EVENTARGUMENT"] == "mya1"){
        //   mya_mya( this, new EventArgs( ) );
        // }
        // if (Request["__EVENTTARGET"] == GUID)
        // {
        //ClientScript.GetPostBackEventReference(this, string.Empty);
        string comment = "";
        string parameter = Request["__EVENTTARGET"];
        if(Request.Cookies["comment"]!=null)
        {
          comment = Request.Cookies["comment"].Value;
        }
        if(parameter!=null){
        if(parameter.ToString().Length>3){
          if(parameter.ToString().Contains("ticket")){
            getticketdataa( this, new EventArgs( ) ,parameter.ToString().Substring(parameter.ToString().Length-1,1));
            //mya_mya( this, new EventArgs( ) ,null);
          }
          HttpContext.Current.Response.AppendToLog("deliveredasdSearchSearch");
          add_comment( this, new EventArgs( ) ,parameter,comment);
        }else{
          mya_mya( this, new EventArgs( ) ,parameter);
        }
        }else{
            mya_mya( this, new EventArgs( ) ,parameter);
        }
        // }
    }

    protected void Login(object sender, EventArgs e)
    {

    }

    protected void SearchButton(object sender, EventArgs e){
      string Search = search.Text;
      string[] Output = new string[]{"id,","title,","username,","cost",",keyword"};
      string Table = "info";
      string Condition = " where keyword like '%"+Search+"%' or title like '%"+Search+"%' order by cost DESC";
      database.open();
      /*string yourDataItems = "<div class='card mb-4'><img class='card-img-top' src='http://placehold.it//750x300' alt='Card image cap'><div class='card-body'><h2 class='card-title' runat='server' ID='cardtitle1'>Post Title</h2><p class='card-text'>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p><a href='#' class='btn btn-primary'>Read More &rarr;</a></div><div class='card-footer text-muted'>Posted on January 1, 2017 by<a href='#'>Start Bootstrap</a></div></div>";
      rptItems.DataSource = yourDataItems;
      rptItems.DataBind();*/
      SqlDataReader sqlDataReader = database.SelectQuery(Output,Table,Condition);
      while(sqlDataReader.Read()/*HasRows*/){
        //sqlDataReader.Read();
        //displaydata(sqlDataReader.GetString(0).ToString(),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(3).ToString());
        displaydata(sqlDataReader.GetString(0),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(4).ToString());
        //displaydata(sqlDataReader.GetString(1),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(3).ToString(),sqlDataReader.GetString(5).ToString());
      }
    }
    protected void getticketdata(object sender, EventArgs e){
      string Search = search.Text;
      string[] Output = new string[]{"id,","title,","username,","email"};
      string Table = "postticket";
      SqlDataReader sqlDataReader;
      //string Condition = " where keyword like '%"+Search+"%' or title like '%"+Search+"%' order by cost DESC";
      string Condition = "";
      database.open();
      sqlDataReader = database.SelectQuery(Output,Table,Condition);
      while(sqlDataReader.Read()/*HasRows*/){
        //sqlDataReader.Read();
        //displaydata(sqlDataReader.GetString(0).ToString(),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(3).ToString());
        displayticketdata(sqlDataReader.GetString(0),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(3).ToString());
        //displaydata(sqlDataReader.GetString(1),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(3).ToString(),sqlDataReader.GetString(5).ToString());
      }
    }

    protected void getticketdataa(object sender, EventArgs e, string parameter){
      string[] Output = new string[]{"id,","title,","username,","email"};
      string Table = "postticket";
      SqlDataReader sqlDataReader;
      string Condition = "";
      database.open();
      if(parameter != null || parameter != ""){
          Condition = " where id = '"+parameter+"'";
          sqlDataReader = database.SelectQuery(Output,Table,Condition);
          while(sqlDataReader.Read()){
            displayfullticketdata(sqlDataReader.GetString(0),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(3).ToString());
          }
      }else{
        sqlDataReader = database.SelectQuery(Output,Table,Condition);
        while(sqlDataReader.Read()){
          displayticketdata(sqlDataReader.GetString(0),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(3).ToString());
        }
      }
      while(sqlDataReader.Read()){
        displayticketdata(sqlDataReader.GetString(0),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(3).ToString());
      }
    }

    protected void displayticketdata(string id, string title, string username,string content){
      HtmlGenericControl myDiv = new HtmlGenericControl("div");
            myDiv.ID = "myDiv" + Guid.NewGuid().ToString("N");
            myDiv.Attributes["class"] = "card mb-4";
            /*LinkButton myLnkBtn = new LinkButton();
            myLnkBtn.ID = "myLnkBtn";
            myLnkBtn.Click += new EventHandler(myLnkBtn_Click);
            myLnkBtn.Text = "I'm dynamic";
            myDiv.Controls.Add(myLnkBtn);*/
      HtmlGenericControl myDiv1 = new HtmlGenericControl("div");
            myDiv1.ID = "myDiv1" + Guid.NewGuid().ToString("N");
            myDiv1.Attributes["class"] = "card-img-top";

      HtmlGenericControl myDiv2 = new HtmlGenericControl("div");
            myDiv2.ID = "myDiv2" + Guid.NewGuid().ToString("N");
            myDiv2.Attributes["class"] = "card-body";

      HtmlGenericControl myH2 = new HtmlGenericControl("h2");
            myH2.ID = "cardtitle1" + Guid.NewGuid().ToString("N");
            myH2.Attributes["class"] = "card-title";
            myH2.InnerHtml = title;
            myDiv2.Controls.Add(myH2);

      HtmlGenericControl myp = new HtmlGenericControl("p");
            myp.ID = "cardtitle2" + Guid.NewGuid().ToString("N");
            myp.Attributes["class"] = "card-text";
            myp.InnerHtml = content;
            myDiv2.Controls.Add(myp);

      //HtmlGenericControl mya = new HtmlGenericControl("Button");

            LinkButton mya = new LinkButton();
            mya.ID = "ticket"+id;
            //mya.Click += new EventHandler(mya_mya);
            //mya.Attributes["runat"] = "server";
            //mya.Attributes["OnClick"]="mya_mya();";
            mya.Attributes["class"] = "btn btn-primary";

            mya.Text = "Read More &rarr;";
            myDiv2.Controls.Add(mya);

            myDiv1.Controls.Add(myDiv2);

            HtmlGenericControl myDiv3 = new HtmlGenericControl("div");
                  myDiv3.ID = "myDiv3" + Guid.NewGuid().ToString("N");
                  myDiv3.Attributes["class"] = "card-footer text-muted";
                  myDiv3.InnerHtml = username;
            HtmlGenericControl mya1 = new HtmlGenericControl("a");
                  mya1.ID = "mya11" + Guid.NewGuid().ToString("N");
                  mya1.Attributes["href"] = "#";
                  mya1.InnerHtml = "Start Bootstrap";
                  myDiv3.Controls.Add(mya1);

            myDiv1.Controls.Add(myDiv3);
            myDiv.Controls.Add(myDiv1);
            PlaceHolder1.Controls.Add(myDiv);
            HttpContext.Current.Response.AppendToLog("deliveredasdSearch1");
    }

    protected void displayfullticketdata(string id, string title, string username,string content){

      HtmlGenericControl myp = new HtmlGenericControl("p");
            myp.ID = "cardtitle2" + Guid.NewGuid().ToString("N");
            myp.Attributes["class"] = "lead";
            myp.InnerHtml = "by "+username;
      PlaceHolder1.Controls.Add(myp);

      HtmlGenericControl myhr = new HtmlGenericControl("hr");
      PlaceHolder1.Controls.Add(myhr);
      HtmlGenericControl myp1 = new HtmlGenericControl("p");
              myp1.ID = "cardtitle2" + Guid.NewGuid().ToString("N");
              myp1.InnerHtml = "Posted on January 1, 2018 at 12:00 PM";
      PlaceHolder1.Controls.Add(myp1);
      HtmlGenericControl myhr1 = new HtmlGenericControl("hr");
      PlaceHolder1.Controls.Add(myhr1);
      HtmlGenericControl myp3 = new HtmlGenericControl("p");
            myp3.ID = "cardtitle2" + Guid.NewGuid().ToString("N");
            myp3.Attributes["class"] = "lead";
            myp3.InnerHtml = content;
      PlaceHolder1.Controls.Add(myp3);
      HtmlGenericControl myhr2 = new HtmlGenericControl("hr");
      PlaceHolder1.Controls.Add(myhr2);
      /*HtmlGenericControl myDiv1 = new HtmlGenericControl("div");
            myDiv1.ID = "myDiv1" + Guid.NewGuid().ToString("N");
            myDiv1.Attributes["class"] = "card my-4";
            HtmlGenericControl myh5 = new HtmlGenericControl("h5");
                  myh5.ID = "myDiv1" + Guid.NewGuid().ToString("N");
                  myh5.Attributes["class"] = "card-header";
                  myh5.InnerHtml = "Leave a Comment:";
                  myDiv1.Controls.Add(myh5);
                  HtmlGenericControl myDiv2 = new HtmlGenericControl("div");
                        myDiv2.ID = "myDiv2" + Guid.NewGuid().ToString("N");
                        myDiv2.Attributes["class"] = "card-body";
                        HtmlGenericControl form = new HtmlGenericControl("form");
                                HtmlGenericControl myDiv3 = new HtmlGenericControl("div");
                                      myDiv3.ID = "myDiv3" + Guid.NewGuid().ToString("N");
                                      myDiv3.Attributes["class"] = "form-group";
                                      HtmlGenericControl textarea = new HtmlGenericControl("textarea");
                                            textarea.Attributes["class"] = "form-control";
                                            textarea.ID = "comment";
                                      myDiv3.Controls.Add(textarea);
                                      LinkButton mya = new LinkButton();
                                            mya.ID = "1000"+id;
                                            //mya.Click += new EventHandler(mya_mya);
                                            //mya.Attributes["runat"] = "server";
                                            //mya.Attributes["OnClick"]="mya_mya();";
                                            mya.Attributes["class"] = "btn btn-primary";
                                            mya.Text = "Submit";
                                      // HtmlGenericControl mya = new HtmlGenericControl("button");
                                      //       mya.ID = "1000"+id;
                                      //       mya.InnerHtml = "Submit";
                                      //       mya.Attributes["class"] = "btn btn-primary";
                                      //       mya.Attributes["value"] = "submit";
                                      form.Controls.Add(myDiv3);
                                      form.Controls.Add(mya);
                                      myDiv2.Controls.Add(form);

            myDiv1.Controls.Add(myDiv2);*/
       //PlaceHolder1.Controls.Add(myDiv1);
    }

    protected void displaydata(string id, string title, string username,string content){
      HtmlGenericControl myDiv = new HtmlGenericControl("div");
            myDiv.ID = "myDiv" + Guid.NewGuid().ToString("N");
            myDiv.Attributes["class"] = "card mb-4";
            /*LinkButton myLnkBtn = new LinkButton();
            myLnkBtn.ID = "myLnkBtn";
            myLnkBtn.Click += new EventHandler(myLnkBtn_Click);
            myLnkBtn.Text = "I'm dynamic";
            myDiv.Controls.Add(myLnkBtn);*/
      HtmlGenericControl myDiv1 = new HtmlGenericControl("div");
            myDiv1.ID = "myDiv1" + Guid.NewGuid().ToString("N");
            myDiv1.Attributes["class"] = "card-img-top";

      HtmlGenericControl myDiv2 = new HtmlGenericControl("div");
            myDiv2.ID = "myDiv2" + Guid.NewGuid().ToString("N");
            myDiv2.Attributes["class"] = "card-body";

      HtmlGenericControl myH2 = new HtmlGenericControl("h2");
            myH2.ID = "cardtitle1" + Guid.NewGuid().ToString("N");
            myH2.Attributes["class"] = "card-title";
            myH2.InnerHtml = title;
            myDiv2.Controls.Add(myH2);

      HtmlGenericControl myp = new HtmlGenericControl("p");
            myp.ID = "cardtitle2" + Guid.NewGuid().ToString("N");
            myp.Attributes["class"] = "card-text";
            myp.InnerHtml = content;
            myDiv2.Controls.Add(myp);

      //HtmlGenericControl mya = new HtmlGenericControl("Button");

            LinkButton mya = new LinkButton();
            mya.ID = id;
            //mya.Click += new EventHandler(mya_mya);
            //mya.Attributes["runat"] = "server";
            //mya.Attributes["OnClick"]="mya_mya();";
            mya.Attributes["class"] = "btn btn-primary";

            mya.Text = "Read More &rarr;";
            myDiv2.Controls.Add(mya);

            myDiv1.Controls.Add(myDiv2);

            HtmlGenericControl myDiv3 = new HtmlGenericControl("div");
                  myDiv3.ID = "myDiv3" + Guid.NewGuid().ToString("N");
                  myDiv3.Attributes["class"] = "card-footer text-muted";
                  myDiv3.InnerHtml = username;
            HtmlGenericControl mya1 = new HtmlGenericControl("a");
                  mya1.ID = "mya11" + Guid.NewGuid().ToString("N");
                  mya1.Attributes["href"] = "#";
                  mya1.InnerHtml = "Start Bootstrap";
                  myDiv3.Controls.Add(mya1);

            myDiv1.Controls.Add(myDiv3);
            myDiv.Controls.Add(myDiv1);
            PlaceHolder1.Controls.Add(myDiv);
            HttpContext.Current.Response.AppendToLog("deliveredasdSearch1");
    }

    protected void mya_mya(object sender, EventArgs e,string parameter)
        {

          PlaceHolder1.Controls.Clear();
          string Search = "";
          string Condition = "";
          //HttpContext.Current.Response.AppendToLog("deliveredasdSearch" + Search);
          // LinkButton lnk = sender as LinkButton;
          // if(lnk!=null){
          //     Search = lnk.ID.ToString();
          // }
          string[] Output = new string[]{"id,","title,","username,","cost",",keyword"};
          string Table = "info";
          SqlDataReader sqlDataReader;
          database.open();
          if(parameter!=null){
              Search = parameter.ToString();
              Condition = " where id = '"+Search+"'order by cost DESC";
              sqlDataReader = database.SelectQuery(Output,Table,Condition);
              while(sqlDataReader.Read()){
                //sqlDataReader.Read();
                displayfulldata(sqlDataReader.GetString(0),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(4).ToString());
              }
          }else{
            sqlDataReader = database.SelectQuery(Output,Table,Condition);
            while(sqlDataReader.Read()){
              //sqlDataReader.Read();
              displaydata(sqlDataReader.GetString(0),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(4).ToString());
            }
          }
        }

        protected void mya_myaa(object sender, EventArgs e)
            {

              PlaceHolder1.Controls.Clear();
              string Condition = "";
              string[] Output = new string[]{"id,","title,","username,","cost",",keyword"};
              string Table = "info";
              SqlDataReader sqlDataReader;
              database.open();
                sqlDataReader = database.SelectQuery(Output,Table,Condition);
                while(sqlDataReader.Read()){
                  //sqlDataReader.Read();
                  displaydata(sqlDataReader.GetString(0),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(4).ToString());
                }
            }

        protected void displayfulldata(string id, string title, string username,string content){

          HtmlGenericControl myp = new HtmlGenericControl("p");
                myp.ID = "cardtitle2" + Guid.NewGuid().ToString("N");
                myp.Attributes["class"] = "lead";
                myp.InnerHtml = "by "+username;
          PlaceHolder1.Controls.Add(myp);

          HtmlGenericControl myhr = new HtmlGenericControl("hr");
          PlaceHolder1.Controls.Add(myhr);
          HtmlGenericControl myp1 = new HtmlGenericControl("p");
                  myp1.ID = "cardtitle2" + Guid.NewGuid().ToString("N");
                  myp1.InnerHtml = "Posted on January 1, 2018 at 12:00 PM";
          PlaceHolder1.Controls.Add(myp1);
          HtmlGenericControl myhr1 = new HtmlGenericControl("hr");
          PlaceHolder1.Controls.Add(myhr1);
          HtmlGenericControl myp3 = new HtmlGenericControl("p");
                myp3.ID = "cardtitle2" + Guid.NewGuid().ToString("N");
                myp3.Attributes["class"] = "lead";
                myp3.InnerHtml = content;
          PlaceHolder1.Controls.Add(myp3);
          HtmlGenericControl myhr2 = new HtmlGenericControl("hr");
          PlaceHolder1.Controls.Add(myhr2);
          HtmlGenericControl myDiv1 = new HtmlGenericControl("div");
                myDiv1.ID = "myDiv1" + Guid.NewGuid().ToString("N");
                myDiv1.Attributes["class"] = "card my-4";
                HtmlGenericControl myh5 = new HtmlGenericControl("h5");
                      myh5.ID = "myDiv1" + Guid.NewGuid().ToString("N");
                      myh5.Attributes["class"] = "card-header";
                      myh5.InnerHtml = "Leave a Comment:";
                      myDiv1.Controls.Add(myh5);
                      HtmlGenericControl myDiv2 = new HtmlGenericControl("div");
                            myDiv2.ID = "myDiv2" + Guid.NewGuid().ToString("N");
                            myDiv2.Attributes["class"] = "card-body";
                            HtmlGenericControl form = new HtmlGenericControl("form");
                                    HtmlGenericControl myDiv3 = new HtmlGenericControl("div");
                                          myDiv3.ID = "myDiv3" + Guid.NewGuid().ToString("N");
                                          myDiv3.Attributes["class"] = "form-group";
                                          HtmlGenericControl textarea = new HtmlGenericControl("textarea");
                                                textarea.Attributes["class"] = "form-control";
                                                textarea.ID = "comment";
                                          myDiv3.Controls.Add(textarea);
                                          LinkButton mya = new LinkButton();
                                                mya.ID = "1000"+id;
                                                //mya.Click += new EventHandler(mya_mya);
                                                //mya.Attributes["runat"] = "server";
                                                //mya.Attributes["OnClick"]="mya_mya();";
                                                mya.Attributes["class"] = "btn btn-primary";
                                                mya.Text = "Submit";
                                          // HtmlGenericControl mya = new HtmlGenericControl("button");
                                          //       mya.ID = "1000"+id;
                                          //       mya.InnerHtml = "Submit";
                                          //       mya.Attributes["class"] = "btn btn-primary";
                                          //       mya.Attributes["value"] = "submit";
                                          form.Controls.Add(myDiv3);
                                          form.Controls.Add(mya);
                                          myDiv2.Controls.Add(form);

                myDiv1.Controls.Add(myDiv2);
           PlaceHolder1.Controls.Add(myDiv1);
        }
        protected void add_comment(object sender, EventArgs e,string parameter,string comment){
          string connectionStirng;
          SqlConnection sqlConnection;
          connectionStirng = ConfigurationManager.ConnectionStrings["OnlineFS"].ConnectionString;
          sqlConnection = new SqlConnection(connectionStirng);
          sqlConnection.Open();
          HttpContext.Current.Response.AppendToLog("deliveredasdparametercomment" + comment + " "+parameter.Length + " ");
          string id = parameter.Substring(0,parameter.Length);

          string insert_query = "insert into comment values('" + id + "','" + comment + "')";
          SqlCommand sqlCommand = new SqlCommand(insert_query, sqlConnection);
          int stat = sqlCommand.ExecuteNonQuery();
        }

        protected void btn_Click(object sender, EventArgs e){
          // string connectionStirng;
          // SqlConnection sqlConnection;
          // connectionStirng = ConfigurationManager.ConnectionStrings["OnlineFS"].ConnectionString;
          // sqlConnection = new SqlConnection(connectionStirng);
          // sqlConnection.Open();
          // HttpContext.Current.Response.AppendToLog("deliveredasdparametercomment" + comment + " "+parameter.Length + " ");
          // string id = parameter.Substring(0,parameter.Length);
          //
          // string insert_query = "insert into comment values('" + id + "','" + comment + "')";
          // SqlCommand sqlCommand = new SqlCommand(insert_query, sqlConnection);
          // int stat = sqlCommand.ExecuteNonQuery();
        }

        protected void fLogin(object sender, EventArgs e){
          Session["UserName"] = "";
          Session["Pwd"] = "";
          Response.Redirect("default.aspx");
        }

        protected void fLogout(object sender, EventArgs e){
          Session["UserName"] = "";
          Session["Pwd"] = "";
          login.Visible = true;
          logout.Visible = false;
          Response.Redirect("index.aspx");
        }

}
