using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saklambac_Contact_App.Models
{
    public class Contact
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string CreatedDate { get; set; }
    }
}