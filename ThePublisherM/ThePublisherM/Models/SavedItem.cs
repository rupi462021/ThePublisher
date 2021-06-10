using ThePublisherM.Controllers;
using ThePublisherM.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ThePublisherM.Models
{
    public class SavedItem
    {
        int id;
        string title;
        int storyNum;
        string description;
        string link;
        public SavedItem() { }

        public SavedItem(int id, string title, int storyNum, string description,string link)
        {
            Id = id;
            Title = title;
            StoryNum = storyNum;
            Description = description;
            Link = link;
        }
        public string Link { get => link; set => link = value; }
        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public int StoryNum { get => storyNum; set => storyNum = value; }
        public string Description { get => description; set => description = value; }

        public void InsertSave()
        {
            DBServices dbs = new DBServices();
            dbs.SaveItemDetails(this);

        }
    }
}