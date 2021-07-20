using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tweetinvi;
using System.Data;
using System.Text;
using System.Web.Configuration;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using ThePublisherM.Models.DAL;
using ThePublisherM.Models;
using System.Web.Http;






namespace ThePublisherM.Models
{
    
    
    public class Twitter
    {
        int id;
        string title;
        int storyNum;
        string description;
        DateTime startDate;
        DateTime endDate;
        
        

        public Twitter() { }

        public Twitter(int id, string title, int storyNum, string description, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Title = title;
            StoryNum = storyNum;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public int StoryNum { get => storyNum; set => storyNum = value; }
        public string Description { get => description; set => description = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }

        public string AuthenticatTwitter() 
        {
            DBS dbs = new DBS();
            return dbs.GetBearerToken();

        }
        public string GetUserTimeline(string bearerToken, string screenName, int count, bool excludeReplies, bool includeRTs)
        {
            DBS dbs = new DBS();
            return dbs.GetUserTimelineJson(bearerToken, screenName, count, excludeReplies, includeRTs);
        }
        
        //test
        //public Twitter GetTweetByDate(DateTime startDate, DateTime endDate)
        //{
        //    DBS dbs = new DBS();
        //    return dbs.GetDate(startDate, endDate);
        //}
        
    }
}