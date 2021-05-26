using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace ThePublisherM.Controllers
{
    internal class RestRequest
    {
        private object pOST;

        public RestRequest(object pOST)
        {
            this.pOST = pOST;
        }

        internal void AddHeader(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        internal void AddParameter(string v1, string v2, ParameterType requestBody)
        {
            throw new NotImplementedException();
        }
    }
}