using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    string connectionStirng;
    SqlConnection sqlConnection;
    string insert_query, select_query;
    SqlCommand sqlCommand;
    int stat;

    protected void Page_Load(object sender, EventArgs e)
    {
        connectionStirng = ConfigurationManager.ConnectionStrings["OnlineFS"].ConnectionString;
        sqlConnection = new SqlConnection(connectionStirng);
        sqlConnection.Open();
    }

    protected void Register(object sender, EventArgs e)
    {
        string Name = name.Text;
        string UserName = username.Text;
        string Password = password.Text;
        string Re_Password = re_password.Text;
        string Role = DdlMonths.SelectedItem.Text;
        if(Role == "Organisation"){
          Role = "karomi";
        }
        if(Name !="" && UserName != "" && Password != "" && Re_Password != "" && Role != "")
        {
            if (Password == Re_Password)
            {
                select_query = "select * from UserDetails where username='" + Name + "' and password='" + Password + "'";
                insert_query = "insert into UserDetails values('" + Name + "','" + UserName + "','" + Password + "','" + Role + "','nomail@gmail.com')";
                sqlCommand = new SqlCommand(select_query, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    status.Text = "User Aleardy Exists.";
                    sqlDataReader.Close();
                }
                else
                {
                    sqlDataReader.Close();
                    SqlCommand sqlCommand1 = new SqlCommand(insert_query, sqlConnection);
                    stat = sqlCommand1.ExecuteNonQuery();
                    if (stat == 1)
                    {
                        status.Text = "User Successfully Registered.";
                    }
                    else
                    {
                        status.Text = "Please Try Again.";
                    }
                }
            }
            else
            {
                status.Text = "Password Mismatch.";
            }
        }
        else
        {
            status.Text = "Please Fill All The Field";
        }
        clearAll();
    }
    protected void clearAll(){
      name.Text = "";
      username.Text = "";
    }
}
