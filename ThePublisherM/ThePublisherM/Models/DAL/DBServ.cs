using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tweetinvi;

namespace ThePublisherM.Models.DAL
{
    public class DBServ
    {
        public SqlDataAdapter da;
        public DataTable dt;
        string connString;
        
        public DBServ()
        {
            connString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString.ToString();
        }
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
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }

        public DataTable SelectC(string query)
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

        public int UpdateC(string query)
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

        public Customer CheckCustomer(string email)
        {

            SqlConnection con = null;
            Customer c = new Customer();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file
                
                String selectSTR = "SELECT * FROM Customers_2021 where email = " + "'" + email + "'";


                SqlCommand cmd = new SqlCommand(selectSTR, con);
                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                while (dr.Read())
                {   // Read till the end of the data into a row                   
                    //Customer c = new Customer();
                    c.Email = (string)dr["email"];
                    c.Access = (string)dr["access"];
                    //cusList.Add(c);
                }

                return c;
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
                    con.Close();
                }

            }

        }
    }
}