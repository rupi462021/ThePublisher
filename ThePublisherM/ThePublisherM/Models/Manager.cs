using ThePublisherM.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThePublisherM.Models
{
    public class Manager
    {
        int id;
        string email;
        string password;

        public Manager(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public Manager() { }

        public Manager Read(string email, string password)
        {
            DBServices dbs = new DBServices();
            return dbs.ReadManager(email, password);


        }
    }
}