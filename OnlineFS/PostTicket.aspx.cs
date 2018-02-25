using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class PostTicket : System.Web.UI.Page
{
    string UserName = "";
    string Password = "";
    Validate validate;

    protected void Page_Load(object sender, EventArgs e)
    {
        validate = new Validate();
        string UserName = Session["UserName"].ToString();
        string Password = Session["Pwd"].ToString();
        if (validate.GetRole(UserName, Password) != "Client")
        {
            Response.Redirect("Exit.aspx");
        }
        else
        {

        }
    }
    protected void Submit(object sender, EventArgs e)
    {
        pcontent.PostedFile.SaveAs(@"c:\Users\Jebin\source\repos\OnlineFS\Upload\" + pcontent.FileName);
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
            //  MessageBox.Show(ex.ToString());
          }
    }

    protected void TicketLogOut(object sender, EventArgs e)
    {
        Session["UserName"] = "";
        Session["Pwd"] = "";
        Response.Redirect("Default.aspx");
    }
}
