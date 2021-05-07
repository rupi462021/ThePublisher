using ThePublisherM.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace ThePublisherM.Models
{
    public class Customer
    {
        int id;
        string fname;
        string lname;
        string email;
        string phoneN;
        string password;
        string access;

        public int Id { get => id; set => id = value; }
        public string Fname { get => fname; set => fname = value; }
        public string Lname { get => lname; set => lname = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneN { get => phoneN; set => phoneN = value; }
        public string Password { get => password; set => password = value; }
        public string Access { get => access; set => access = value; }

        public Customer() { }

        public Customer(int id, string fname, string lname, string email, string phoneN, string password, string access)
        {
            Id = id;
            Fname = fname;
            Lname = lname;
            Email = email;
            PhoneN = phoneN;
            Password = password;
            Access = access;
        }

        public Customer Read(string email, string password)
        {
            DBServices dbs = new DBServices();
            return dbs.ReadCustomer(email, password);              
        }
        public void InsertC()
        {
            DBServices dbs = new DBServices();
            dbs.InsertCustomer(this);
        }
        public Customer Check(string email)
        {
            DBServ dbs = new DBServ();
            return dbs.CheckCustomer(email);
        }
        

    }
}