using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tweetinvi;
using System.Data;
using System.Text;
using System.Web.Configuration;

using System.Threading.Tasks;
using ThePublisherM.Models.DAL;

namespace ThePublisherM.Models
{
    
    public class Twitter
    {
        int id;
        string title;
        int storyNum;
        string description;

        public Twitter(int id, string title, int storyNum, string description)
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

        public Twitter() { }

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
    }
}