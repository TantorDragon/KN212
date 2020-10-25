using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Core.Models
{
    public class User : Item
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
