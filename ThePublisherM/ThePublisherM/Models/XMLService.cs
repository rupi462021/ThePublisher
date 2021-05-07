using ThePublisherM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Schema;
using System.Xml.XmlConfiguration;
using System.IO;
using System.Text;

namespace ThePublisherM.Controllers
{
    public class XMLService
    {
        //Read all the lineup show- first go to this function
        public List<Item> Check()
        {
            String xmlFile = HttpContext.Current.Server.MapPath("~/App_Data/xmlfiles");
            List<Item> tList = new List<Item>();
            XmlDocument doc = new XmlDocument();
            //var path = @"C:\Users\reute\Desktop\xmlfiles";
            foreach (var file in Directory.GetFiles(xmlFile))
            {

                XPathNavigator nav = new XPathDocument(file).CreateNavigator();
                string xpath = "/rundown";
                foreach (XPathNavigator node in nav.Select(xpath))
                {
                    tList.Add(ReadShowNode(node));
                }
            }
            return tList;
        }


        public Item ReadShowNode(XPathNavigator node)
        {
            XPathNavigator n = node.SelectSingleNode("//show/show.title");
            string showTitle = n == null ? string.Empty : n.Value; // manage the case the name is empty

            n = node.SelectSingleNode("//show/show.showId");
            int showId;
            if (n != null)
            {
                try
                {
                    showId = Convert.ToInt32(n.Value);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in converting the id :" + n.Value + " , Error message is :" + ex.Message);
                }
            }
            else
            {
                showId = Int32.MinValue;
            }
            n = node.SelectSingleNode("//story/story.name");
            string storyName = n == null ? string.Empty : n.Value;
            n = node.SelectSingleNode("//story/story.format");
            string storyFormat = n == null ? string.Empty : n.Value; // manage the case the name is empty
            n = node.SelectSingleNode("//story/story.script");
            string storyScript = n == null ? string.Empty : n.Value; // manage the case the name is empty

            n = node.SelectSingleNode("//story/story.storyId");
            int stotyId;
            if (n != null)
            {
                stotyId = Convert.ToInt32(n.Value);
            }
            else
            {

                stotyId = Int32.MinValue;
            }

            return new Item(showTitle, showId, storyName, storyFormat, storyScript, stotyId);

        }



    }
}



