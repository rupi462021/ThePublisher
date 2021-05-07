using ThePublisherM.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThePublisherM.Models
{
    public class Video
    {
        string id;
        string channelTitle;
        string description;
        string title;
        string ifrmae;

        public Video() { }

        public Video(string id, string channelTitle, string description, string title, string ifrmae)
        {
            this.id = id;
            this.channelTitle = channelTitle;
            this.description = description;
            this.title = title;
            this.ifrmae = ifrmae;
        }

        public string Id { get => id; set => id = value; }
        public string ChannelTitle { get => channelTitle; set => channelTitle = value; }
        public string Description { get => description; set => description = value; }
        public string Title { get => title; set => title = value; }
        public string Ifrmae { get => ifrmae; set => ifrmae = value; }


        public void Insert()
        {
            DBSERvvv dbs = new DBSERvvv();
            dbs.InsertVideo(this);
        }


        public List<Video> Read()
        {

            DBSERvvv dbs = new DBSERvvv();
            List<Video> vList = dbs.Getvideotitle();
            return vList;

        }
        public List<Video> getItem(string id)
        {

            DBSERvvv dbs = new DBSERvvv();
            List<Video> iList = dbs.GetItemtitle(id);
            return iList;

        }
    }
}