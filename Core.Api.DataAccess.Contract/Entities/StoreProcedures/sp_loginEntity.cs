using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api.DataAccess.Contract.Entities.StoreProcedures
{
    public class sp_loginEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string IPAddress { get; set; }
        public string Hostname { get; set; }
        // OutPut
        public int ID { get; set; }
    }
}
