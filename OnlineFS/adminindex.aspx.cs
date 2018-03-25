using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class AdminIndex : System.Web.UI.Page
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
            if(parameter.ToString().Contains("2")){
              approve( this, new EventArgs( ) ,parameter.ToString().Substring(parameter.ToString().Length-1,1));
              mya_mya( this, new EventArgs( ) ,null);
            }
            else if(parameter.ToString().Contains("3")){
              remove( this, new EventArgs( ) ,parameter.ToString().Substring(parameter.ToString().Length-1,1));
              mya_mya( this, new EventArgs( ) ,null);
            }
            else{
              HttpContext.Current.Response.AppendToLog("deliveredasdSearchSearch");
              add_comment( this, new EventArgs( ) ,parameter.ToString().Substring(parameter.ToString().Length-1,1),comment);
              mya_mya( this, new EventArgs( ) ,parameter.ToString().Substring(parameter.ToString().Length-1,1));
            }
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
      string Table = "admindb ";
      string Condition = " where keyword like '%"+Search+"%' or title like '%"+Search+"%' order by cost DESC";
      database.open();
      SqlDataReader sqlDataReader = database.SelectQuery(Output,Table,Condition);
      while(sqlDataReader.Read()/*HasRows*/){
        displaydata(sqlDataReader.GetString(0),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(4).ToString());
      }
    }

    protected void displaydata(string id, string title, string username,string content){
      HtmlGenericControl myDiv = new HtmlGenericControl("div");
            myDiv.ID = "myDiv" + Guid.NewGuid().ToString("N");
            myDiv.Attributes["class"] = "card mb-4";
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
          string[] Output = new string[]{"id,","title,","username,","cost",",keyword",",status"};
          string Table = "admindb";
          SqlDataReader sqlDataReader;
          database.open();
          if(parameter!=null){
              Search = parameter.ToString();
              //Condition = " where status = 'pending' and id = '"+Search+"'order by cost DESC";
              Condition = " where id = '"+Search+"'order by cost DESC";
              sqlDataReader = database.SelectQuery(Output,Table,Condition);
              while(sqlDataReader.Read()){
                //if(sqlDataReader.GetString(5).ToString()=="pending"){
                  displayfulldata(sqlDataReader.GetString(0),
                  sqlDataReader.GetString(1).ToString(),
                  sqlDataReader.GetString(2).ToString(),
                  sqlDataReader.GetString(4).ToString(),
                  sqlDataReader.GetString(5).ToString());
                }
          }else{
            Condition = " where status = 'pending' order by cost DESC";
            sqlDataReader = database.SelectQuery(Output,Table,Condition);
            while(sqlDataReader.Read()){
              displaydata(sqlDataReader.GetString(0),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(4).ToString());
            }
          }
        }

        protected void displayfulldata(string id, string title, string username,string content,string status){

          LinkButton approve = new LinkButton(), reject = new LinkButton();
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
                                                mya.Attributes["class"] = "btn btn-primary";
                                                mya.Text = "Submit";
                                                if(status == "pending"){

                                                approve.ID = "2000"+id;
                                                approve.Attributes["class"] = "btn btn-primary";
                                                approve.Text = "Approve";
                                                approve.Click += new EventHandler(myLnkBtn_Click);
                                          //reject = new LinkButton();
                                                reject.ID = "3000"+id;
                                                reject.Attributes["class"] = "btn btn-primary";
                                                reject.Text = "Reject";
                                              }

                                          form.Controls.Add(myDiv3);
                                          form.Controls.Add(mya);
                                          if(status == "pending"){
                                            form.Controls.Add(approve);
                                            form.Controls.Add(reject);
                                          }
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
        protected void approve(object sender, EventArgs e,string parameter){
          PlaceHolder1.Controls.Clear();
          string Search = "";
          string Condition = "";
          string[] Output = new string[]{"*"};
          string Table = "admindb";
          SqlDataReader sqlDataReader;
          database.open();
          Search = parameter.ToString();
          Condition = " where id = '"+parameter+"'";
          sqlDataReader = database.SelectQuery(Output,Table,Condition);
          sqlDataReader.Read();
          //displayfulldata(sqlDataReader.GetString(0),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(3).ToString(),sqlDataReader.GetString(4).ToString(),sqlDataReader.GetString(5).ToString(),sqlDataReader.GetString(6).ToString(),sqlDataReader.GetString(7).ToString());

          string connectionStirng;
          SqlConnection sqlConnection;
          connectionStirng = ConfigurationManager.ConnectionStrings["OnlineFS"].ConnectionString;
          sqlConnection = new SqlConnection(connectionStirng);
          sqlConnection.Open();
          HttpContext.Current.Response.AppendToLog("deliveredasdparametercomment parameter a"+parameter+ " ");
          string id = parameter.Substring(0,parameter.Length);
          string insert_query = "insert into info1 values('"+sqlDataReader.GetString(0)+"','"+sqlDataReader.GetString(1).ToString()+"','"+sqlDataReader.GetString(2).ToString()+"','"+sqlDataReader.GetString(3).ToString()+"','"+sqlDataReader.GetString(6).ToString()+"')";
          string update_query = "update admindb set status = 'completed' where id ='"+parameter+"'";
          SqlCommand sqlCommand = new SqlCommand(insert_query, sqlConnection);
          SqlCommand sqlCommand1 = new SqlCommand(update_query, sqlConnection);
          int stat = sqlCommand.ExecuteNonQuery();
          int stat1 = sqlCommand1.ExecuteNonQuery();
        }

        protected void remove(object sender, EventArgs e,string parameter){
          string connectionStirng;
          SqlConnection sqlConnection;
          connectionStirng = ConfigurationManager.ConnectionStrings["OnlineFS"].ConnectionString;
          sqlConnection = new SqlConnection(connectionStirng);
          sqlConnection.Open();
          //HttpContext.Current.Response.AppendToLog("deliveredasdparametercomment" + comment + " "+parameter.Length + " ");
          string id = parameter.Substring(0,parameter.Length);
          string insert_query = "update admindb set status = 'reject' where id ='"+parameter+"'";
          SqlCommand sqlCommand = new SqlCommand(insert_query, sqlConnection);
          int stat = sqlCommand.ExecuteNonQuery();
        }

        protected void getrejecteddata(object sender, EventArgs e){
          PlaceHolder1.Controls.Clear();
          string Search = "";
          string Condition = "";
          string[] Output = new string[]{"id,","title,","username,","cost",",keyword"};
          string Table = "admindb";
          SqlDataReader sqlDataReader;
          database.open();
          // if(parameter!=null){
            Condition = " where status = 'reject' order by cost DESC";
            sqlDataReader = database.SelectQuery(Output,Table,Condition);
            while(sqlDataReader.Read()){
              displaydata(sqlDataReader.GetString(0),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(4).ToString());
            }
          // }
        }
        protected void getpendingdata(object sender, EventArgs e){
          PlaceHolder1.Controls.Clear();
          string Search = "";
          string Condition = "";
          string[] Output = new string[]{"id,","title,","username,","cost",",keyword"};
          string Table = "admindb";
          SqlDataReader sqlDataReader;
          database.open();
          // if(parameter!=null){
            Condition = " where status = 'pending' order by cost DESC";
            sqlDataReader = database.SelectQuery(Output,Table,Condition);
            while(sqlDataReader.Read()){
              displaydata(sqlDataReader.GetString(0),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(4).ToString());
            }
          // }
        }
        protected void getcompleteddata(object sender, EventArgs e){
          PlaceHolder1.Controls.Clear();
          string Search = "";
          string Condition = "";
          string[] Output = new string[]{"id,","title,","username,","cost",",keyword"};
          string Table = "admindb";
          SqlDataReader sqlDataReader;
          database.open();
          // if(parameter!=null){
            Condition = " where status = 'completed' order by cost DESC";
            sqlDataReader = database.SelectQuery(Output,Table,Condition);
            while(sqlDataReader.Read()){
              displaydata(sqlDataReader.GetString(0),sqlDataReader.GetString(1).ToString(),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(4).ToString());
            }
          // }
        }

        protected void myLnkBtn_Click(object sender, EventArgs e){
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
          Response.Redirect("adminindex.aspx");
        }
}
