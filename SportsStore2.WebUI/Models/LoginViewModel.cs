﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsStore2.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Please enter a username.")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Please enter a password.")]
        public string Password { get; set; }
    }
}