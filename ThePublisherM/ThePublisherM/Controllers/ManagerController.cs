using ThePublisherM.Models;
using ThePublisherM.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ThePublisherM.Controllers
{
    public class ManagerController : ApiController
    {
        // GET api/<controller>
        public Manager Get(string email, string password)
        {
            Manager m = new Manager();
            return m.Read(email, password);

        }
        public DataTable Get()
        {
            DBServ dsr = new DBServ();
            string query = "SELECT * FROM Customers_2021";
            return dsr.SelectC(query);
        }
        // PUT api/<controller>/5
        public void Put(int id, [FromBody] EditP value)
        {
            string q = "UPDATE Customers_2021 SET fname='" + value.fname + "', lname='"+ value.lname + "', email='"+value.email+
             "', access='" + value.access + "' WHERE id=" + id;
            DBServ dsr = new DBServ();
            dsr.UpdateC(q);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            string q = "DELETE FROM Customers_2021 WHERE Id=" + id;
            DBServ dsr = new DBServ();
            dsr.UpdateC(q);
        }
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}