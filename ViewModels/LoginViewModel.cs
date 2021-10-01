using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using KamelijaWeb.Data.Entities;

namespace KamelijaWeb.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password{ get; set; }
        public bool RememberMe { get; set; }
    }
}
