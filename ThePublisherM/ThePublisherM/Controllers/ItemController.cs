using ThePublisherM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using System.Xml.XmlConfiguration;
using System.IO;
using System.Text;


namespace ThePublisherM.Controllers
{
    public class ItemController : ApiController
    {

        public List<Item> Get()
        {
            Item ite = new Item();
            return ite.ReadItem();
        }

    }
}