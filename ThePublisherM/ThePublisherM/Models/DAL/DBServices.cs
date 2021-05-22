using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Windows;
using System.Configuration;
using ThePublisherM.Models;

namespace ThePublisherM.Models.DAL
{
    public class DBServices
    {
        public SqlDataAdapter da;
        public DataTable dt;

        public Manager ReadManager(string email, string password)
        {

            SqlConnection con = null;
            Manager m = new Manager();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Managers_2021 where email = " + "'" + email + "'" + " and password = " + "'" + password + "'";

                SqlCommand cmd = new SqlCommand(selectSTR, con);
                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                while (dr.Read())
                {   // Read till the end of the data into a row                   
                    m.Email = (string)dr["email"];
                    m.Password = (string)dr["password"];
                }

                return m;
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
        public Customer ReadCustomer(string email, string password)
        {

            SqlConnection con = null;
            Customer c = new Customer();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file
                
                String selectSTR = "SELECT * FROM Customers_2021 where email = " + "'" + email + "'" + " and password = " + "'" + password + "'" + " and access <> 'NULL' ";

                SqlCommand cmd = new SqlCommand(selectSTR, con);
                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                while (dr.Read())
                {   // Read till the end of the data into a row                   
                    c.Email = (string)dr["email"];
                    c.Password = (string)dr["password"];
                    c.Access = (string)dr["access"];
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

        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }
        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }

        //insert save item
        public int SaveItemDetails(SavedItem savedItem)
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

            String cStr = BuildInsertSavedItemCommand(savedItem);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw new Exception("faild" + ex.Message);
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

        private String BuildInsertSavedItemCommand(SavedItem savedItem)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}')", savedItem.Title ,savedItem.StoryNum, savedItem.Description);
            String prefix = "INSERT INTO SaveItem_2021 " + "(title, storyNum, description)";
            command = prefix + sb.ToString();

            return command;
        }

        public int InsertCustomer(Customer customer)
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

            String cStr = BuildInsertCustomerCommand(customer);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
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
        private String BuildInsertCustomerCommand(Customer customer)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}')", customer.Fname, customer.Lname, customer.Email, customer.PhoneN, customer.Password);
            String prefix = "INSERT INTO Customers_2021 " + "(fname, lname, email, phoneN, password) ";
            command = prefix + sb.ToString();

            return command;
        }
    }

    


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>


}
