using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walliny.Models
{
    class RegisterBindingModel
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Cellphone { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

    }
}
