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
        public SavedItem() { }

        public SavedItem(int id, string title, int storyNum, string description)
        {
            Id = id;
            Title = title;
            StoryNum = storyNum;
            Description = description;
        }

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