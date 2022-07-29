using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FG.Domain.DataEntity
{
    public class Login
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
