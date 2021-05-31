using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.XmlConfiguration;
using System.IO;
using System.Text;
using Tweetinvi;
using System.Threading.Tasks;
using ThePublisherM.Models;

namespace ThePublisherM.Controllers
{
    public class TwitterController : ApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        public string Get()
        {
            Twitter tw = new Twitter();
            return tw.AuthenticatTwitter();
        }
        public string Get(string bearerToken, string screenName, int count, bool excludeReplies, bool includeRTs)
        {
            Twitter twi = new Twitter();
            return twi.GetUserTimeline(bearerToken, screenName, count, excludeReplies, includeRTs);
        }
        //public Twitter Get(DateTime startDate, DateTime endDate)
        //{
        //    Twitter twit = new Twitter();
        //    return twit.GetTweetByDate(startDate, endDate);

        //}

        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        //public void Post([FromBody] Twitter tw)
        //{
        //    tw.AuthenticatTwitter();
        //}

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}