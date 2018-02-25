using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

public class Validate
{
    Database database;
    CustomSession session;
    string Condition = "", Table = "";
    string[] Output;
    SqlDataReader sqlDataReader;

    public Validate()
    {
        database = new Database();
    }

    public string GetRole(string username, string password)
    {
        if(username != "" && password != "")
        {
            database.open();
            Condition = " where username = '" + username + "' and password = '" + password +"'";
            Table = "UserDetails";
            Output = new string[] { "role" };
            sqlDataReader = database.SelectQuery(Output, Table, Condition);
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                if (sqlDataReader.GetString(0) == "karomi")
                {
                    sqlDataReader.Close();
                    return "Karomi";
                }
                else
                {
                    sqlDataReader.Close();
                    return "Client";
                }
            }
            else
            {
                sqlDataReader.Close();
                return "Please Register";
            }
        }
        return "Username or Password is Empty";
    }
}
