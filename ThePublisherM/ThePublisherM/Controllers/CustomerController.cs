using ThePublisherM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ThePublisherM.Controllers
{
    public class CustomerController : ApiController
    {
        // GET api/<controller>
        public Customer Get(string email, string password)
        {
            Customer c = new Customer();
            return c.Read(email, password);

        }
        public Customer Get(string email)
        {
            Customer c = new Customer();
            return c.Check(email);

        }
        // POST api/<controller>
        public void Post([FromBody] Customer cr)
        {
            cr.InsertC();
            
        }




        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}