using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api.DataAccess.Contract.Entities.StoreProcedures
{
    public class sp_logoutEntity
    {
        public long Code { get; set; }
        public string IPAddress { get; set; }
        public string Hostname { get; set; }
    }
}
