using ThePublisherM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ThePublisherM.Controllers
{

    public class VideosController : ApiController
    {
        // GET api/<controller>
        public List<Video> Get()
        {
            Video video = new Video();
            List<Video> VList = video.Read();
            return VList;
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/videos/getItem")]
        public List<Video> Get(string id)
        {
            Video video = new Video();
            List<Video> IList = video.getItem(id);
            return IList;
        }

        // POST api/<controller>
        public void Post([FromBody] Video video)

        {
            video.Insert();
        }

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