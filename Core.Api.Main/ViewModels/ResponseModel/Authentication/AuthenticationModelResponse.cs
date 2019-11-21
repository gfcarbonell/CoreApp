using Core.Api.Business.Core;
using Core.Api.Business.Core.StoreProcedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Main.ViewModels.ResponseModel.Authentication
{
    public class AuthenticationModelResponse : ModelResponse
    {
        public LoginModelResponse Login { get; set; }
        public LogoutModelResponse Logout { get; set; }
        public UserModelResponse User { get; set; }
        //public IEnumerable<Business.Core.System> Systems { get; set; }
        public IEnumerable<SystemModelResponse> Systems { get; set; }

        
    }
}
