using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api.Business.StoreProcedures
{
    public class sp_logout
    {
        public long Code { get; set; }
        public string IPAddress { get; set; }
        public string Hostname { get; set; }
    }
}
