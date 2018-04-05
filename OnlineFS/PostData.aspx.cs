using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class PostData : System.Web.UI.Page
{
    string UserName = "";
    string Password = "";
    string title = "";
    string ccontent = "";
    string keyword = "";
    string path = "";
    Validate validate;
    Database database;

    protected void Page_Load(object sender, EventArgs e)
    {
        validate = new Validate();
        database = new Database();
        checkuser();
        if (validate.GetRole(UserName, Password) != "karomi")
        {
            Response.Redirect("default.aspx");
        }
    }
    protected void Submit(object sender, EventArgs e)
    {
      title = pTextBox_title.Text;
      ccontent = pTextBox_description.Text;
      keyword = pTextBox_keyword.Text;
      string connectionStirng;
      string id = "0";
      SqlConnection sqlConnection;
      connectionStirng = ConfigurationManager.ConnectionStrings["OnlineFS"].ConnectionString;
      sqlConnection = new SqlConnection(connectionStirng);
      sqlConnection.Open();
      //HttpContext.Current.Response.AppendToLog("deliveredasdparametercomment" + comment + " "+parameter.Length + " ");
      //string id = parameter.Substring(0,parameter.Length);
      //select top 1 CAST(id AS int) as id1 from admindb order by id1 desc
      string[] Output = new string[]{" top 1 CAST(id AS int) as id1"};
      string Table = " admindb";
      string Condition = " order by id1 desc";
      database.open();
      SqlDataReader sqlDataReader = database.SelectQuery(Output,Table,Condition);
      while(sqlDataReader.Read()/*HasRows*/){
         id = (sqlDataReader.GetInt32(0)+1).ToString();
        //displaydata(sqlDataReader.GetString(1),sqlDataReader.GetString(2).ToString(),sqlDataReader.GetString(3).ToString(),sqlDataReader.GetString(5).ToString());
      }
      //if(pcontent.FileName != null){
        //path = @"c:\Users\Jebin\source\repos\OnlineFS\Upload\" + pcontent.FileName + id;
        //pcontent.PostedFile.SaveAs(path);
      //}
      ///
      string insert_query = "insert into admindb values ('"+id+"','" + title + "','" + ccontent + "','" + keyword + "','" + path + "','pending','"+UserName+"','1')";
      SqlCommand sqlCommand = new SqlCommand(insert_query, sqlConnection);
      int stat = sqlCommand.ExecuteNonQuery();
      clearAll();
    }

    protected void clearAll(){
      pTextBox_title.Text = "";
      pTextBox_description.Text = "";
      pTextBox_keyword.Text = "";
    }

    protected void checkuser()
    {
      try{
        UserName = Session["UserName"].ToString();
        Password = Session["Pwd"].ToString();
      }catch(Exception e){
        Response.Redirect("default.aspx");
      }
    }


    protected void SendMail(object sender, EventArgs e)
    {
      try
      {
        SmtpClient smtp = new SmtpClient();
        smtp.Credentials = new System.Net.NetworkCredential("jebin2einstein12@gmail.com", "nibej212");
        smtp.Port = 587;
        smtp.Host = "smtp.gmail.com";
        smtp.EnableSsl = true;

        MailMessage message = new MailMessage();
        message.From = new MailAddress("jebin2einstein12@gmail.com");
        message.To.Add("jebineinstein@gmail.com");
        message.Subject = "subject";
        message.Body = "messageBody";
        HttpContext.Current.Response.AppendToLog("deliveredasd9");
        smtp.Send(message);
          /*MailMessage mail = new MailMessage();
          SmtpClient SmtpServer = new SmtpClient();
          HttpContext.Current.Response.AppendToLog("deliveredasd1");
          mail.From = new MailAddress("jebin2einstein12@gmail.com");
          HttpContext.Current.Response.AppendToLog("deliveredasd2");
          mail.To.Add("jebineinstein@gmail.com");
          HttpContext.Current.Response.AppendToLog("deliveredasd3");
          mail.Subject = "Test Mail";
          HttpContext.Current.Response.AppendToLog("deliveredasd4");
          mail.Body = "This is for testing SMTP mail from GMAIL";
          HttpContext.Current.Response.AppendToLog("deliveredasd5");

          SmtpServer.Port = 587;
          HttpContext.Current.Response.AppendToLog("deliveredasd6");
          SmtpServer.Credentials = new System.Net.NetworkCredential("jebin2einstein12@gmail.com", "nibej212");
          HttpContext.Current.Response.AppendToLog("deliveredasd7");
          SmtpServer.EnableSsl = true;
          HttpContext.Current.Response.AppendToLog("deliveredasd8");
          SmtpServer.Send(mail);*/
        HttpContext.Current.Response.AppendToLog("deliveredasd9");
          //MessageBox.Show("mail Send");
      }
      catch (Exception ex)
      {
        HttpContext.Current.Response.AppendToLog("undelivered");
      }
    }
}
