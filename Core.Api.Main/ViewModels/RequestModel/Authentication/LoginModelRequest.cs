﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Main.ViewModels.RequestModel.Authentication
{
    public class LoginModelRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
