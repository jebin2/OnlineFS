using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

public class Database
{
    string connectionString = "";
    string insert_query = "", select_query = "";
    SqlCommand sqlCommand;
    static SqlConnection sqlConnection;
    SqlDataReader sqlDataReader;

    public Database()
    {
        connectionString = ConfigurationManager.ConnectionStrings["OnlineFS"].ConnectionString;
    }

    public void open()
    {
        sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
    }

    public SqlDataReader SelectQuery(string[] output, string Table, string condition)
    {
        select_query = "select ";
        for(int i = 0; i < output.Length; i++)
        {
            select_query += " " + output[i] + " ";
        }
        select_query += "from "+Table + condition;
        HttpContext.Current.Response.AppendToLog("Page delivered"+select_query);
        sqlCommand = new SqlCommand(select_query, sqlConnection);
        sqlDataReader = sqlCommand.ExecuteReader();
        return sqlDataReader;
    }

    public void close()
    {
        sqlConnection.Close();
    }
}
