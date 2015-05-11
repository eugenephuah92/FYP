using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SQLCLASS
{
    public class SQLConnectionClass
    {
        SqlConnection SQLConn = new SqlConnection();
        public DataTable SQLTable = new DataTable();


        /// <summary>
        /// constructor with a sepcified database name that have been added to the web config
        /// </summary>
        /// <param name="DatabaseName">connection string base on web config</param>
        public SQLConnectionClass(string DatabaseName)
        {
            SQLConn.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        }

        /// <summary>
        /// retrive data from databse base on the command that passed to the function
        /// </summary>
        /// <param name="command">SQL Command</param>
        public void retrieveData(string command)
        {
            try
            {
                SQLConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command, SQLConn);
                adapter.Fill(SQLTable);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                SQLConn.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        public void executeCommand(string command)
        {
            try
            {
                SQLConn.Open();
                SqlCommand sqlcmd = new SqlCommand(command, SQLConn);
                int rowinfected = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                SQLConn.Close();
            }
        }
    }
}