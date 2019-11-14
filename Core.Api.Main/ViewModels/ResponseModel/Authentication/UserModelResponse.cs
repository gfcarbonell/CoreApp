using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Main.ViewModels.ResponseModel.Authentication
{
    public class UserModelResponse
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
    }
}
