using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using ThePublisherM.Models;
using System.Windows;
using System.Configuration;


/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
/// 
namespace ThePublisherM.Models.DAL
{

    public class DBServicesS
    {
        public SqlDataAdapter da;
        public DataTable dt;

        string connString;

        public DBServicesS()
        {
            connString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString.ToString();
        }

        //--------------------------------------------------------------------------------------------------
        // This method creates a connection to the database according to the connectionString name in the web.config 
        //--------------------------------------------------------------------------------------------------
        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }

        public DataTable Select(string query)
        {
            SqlConnection con;
            SqlCommand cmd;
            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            DataTable dt = new DataTable();
            cmd = CreateCommand(query, con);

            try
            {
                dt.Load(cmd.ExecuteReader()); // execute the command
                return dt;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        //--------------------------------------------------------------------------------------------------
        // This method inserts a car to the cars table 
        //--------------------------------------------------------------------------------------------------
        public int Update(string query)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            //String cStr = BuildInsertCommand(saveditems);      // helper method to build the insert string

            cmd = CreateCommand(query, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        //--------------------------------------------------------------------
        // Build the Insert command String
        //--------------------------------------------------------------------
        //private String BuildInsertCommand(Saveditems saveditems)
        //{
        //    String command;

        //    StringBuilder sb = new StringBuilder();
        //    // use a string builder to create the dynamic string
        //    sb.AppendFormat("Values('{0}', '{1}', '{2}')", saveditems.id, saveditems.title, saveditems.description);
        //    String prefix = "INSERT INTO SavedItems_2021 " + "(id, title, description) ";
        //    command = prefix + sb.ToString();

        //    return command;
        //}
        //---------------------------------------------------------------------------------
        // Create the SqlCommand
        //---------------------------------------------------------------------------------
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }
    }
}
