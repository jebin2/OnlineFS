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
    string connectionString;
    SqlConnection sqlConnection;
    string insert_query,select_query;
    SqlCommand sqlCommand;
    int stat;

    protected void Page_Load(object sender, EventArgs e)
    {
        PostData.Visible = false;
        connectionString = ConfigurationManager.ConnectionStrings["OnlineFS"].ConnectionString;
        sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
    }

    protected void Login(object sender, EventArgs e)
    {
        string UserName = username.Text;
        string Password = password.Text;
        select_query = "select * from UserDetails where username='"+UserName+"' and password='"+Password+"'";
        sqlCommand = new SqlCommand(select_query, sqlConnection);
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        if (sqlDataReader.HasRows)
        {
            status.Text = "Successfully Logged in.";
            PostData.Visible = true;
            sqlDataReader.Close();
        }
        else
        {
            sqlDataReader.Close();
            status.Text = "Please Register";
        }
    }
}