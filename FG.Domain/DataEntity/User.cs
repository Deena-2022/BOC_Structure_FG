
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FG.Domain.DataEntity
{
    public class User
    {
        [Key]
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Companyname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Passwordagain { get; set; }

        public string Timezone { get; set; }

        public string Streetaddress_1 { get; set; }

        public string Streetaddress_2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }
}
