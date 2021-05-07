using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThePublisherM.Controllers;

namespace ThePublisherM.Models
{
    public class RowEdit
    {
        public int id { get; set; }
        public int storyNum { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}