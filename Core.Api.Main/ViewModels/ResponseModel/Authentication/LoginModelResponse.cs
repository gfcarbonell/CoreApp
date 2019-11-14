using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Main.ViewModels.ResponseModel.Authentication
{
    public class LoginModelResponse
    {
        public long Code { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresDate { get; set; }
    }
}
