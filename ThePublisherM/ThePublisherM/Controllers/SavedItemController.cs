using ThePublisherM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.IO;
using System.Data;
using ThePublisherM.Models.DAL;

namespace ThePublisherM.Controllers
{
    public class SavedItemController : ApiController
    {
        // GET api/<controller>
        public DataTable Get()
        {
            DBServices ds = new DBServices();
            string query = "SELECT * FROM SaveItem_2021";
            return ds.Select(query);
        }
        //// GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        // PUT api/<controller>/5
        public void Put(int storyNum, [FromBody] RowEdit value)
        {
            string q = "UPDATE SaveItem_2021 SET description='" + value.description + "', title='" + value.title + "' WHERE storyNum=" + storyNum;
            DBServices ds = new DBServices();
            ds.Update(q);
        }
        // DELETE api/<controller>/5
        public void Delete(int storyNum)
        {
            string q = "DELETE FROM SaveItem_2021 WHERE storyNum=" + storyNum;
            DBServices ds = new DBServices();
            ds.Update(q);
        }
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

       

        // POST api/<controller>
        //[Route("api/SavedItem")]
        //[Route("")]
        //[HttpPost]
        //[Route("api/SavedItem")]
        public void Post([FromBody] SavedItem sv)
        {
             sv.InsertSave();
        }

        // PUT api/<controller>/5
        

        // DELETE api/<controller>/5
        
    }
}