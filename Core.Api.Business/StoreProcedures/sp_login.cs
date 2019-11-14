using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Core.Api.Business.Core.StoreProcedures
{
    public class sp_login
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string IPAddress { get; set; }
        public string Hostname { get; set; }
        // OutPut
        public int ID { get; set; }
    }
}
