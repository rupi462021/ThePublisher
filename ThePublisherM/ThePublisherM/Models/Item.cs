using ThePublisherM.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ThePublisherM.Models
{
    public class Item
    {
        string showTitle;
        int showId;
        string storyName;
        string storyFormat;
        string storyScript;
        int storyId;


        public Item() { }



        public Item(string showTitle, int showId, string storyName, string storyFormat, string storyScript, int storyId)
        {
            ShowTitle = showTitle;
            ShowId = showId;
            StoryName = storyName;
            StoryFormat = storyFormat;
            StoryScript = storyScript;
            StoryId = storyId;
        }

        public string ShowTitle { get => showTitle; set => showTitle = value; }
        public int ShowId { get => showId; set => showId = value; }
        public string StoryName { get => storyName; set => storyName = value; }
        public string StoryFormat { get => storyFormat; set => storyFormat = value; }
        public string StoryScript { get => storyScript; set => storyScript = value; }
        public int StoryId { get => storyId; set => storyId = value; }


        //Read all the lineup show
        public List<Item> ReadItem()
        {
            XMLService xmls = new XMLService();
            return xmls.Check();
        }
        //public List<Item> ReadItem()
        //{
        //    XMLServiceItem xmls = new XMLServiceItem();
        //    return xmls.Check();
        //}       
    }
}