﻿using RestSharp;
using System;

namespace ThePublisherM.Controllers
{
    internal class RestClient
    {
        private string v;

        public RestClient(string v)
        {
            this.v = v;
        }

        public int Timeout { get; internal set; }

        internal IRestResponse Execute(RestRequest request)
        {
            throw new NotImplementedException();
        }
    }
}