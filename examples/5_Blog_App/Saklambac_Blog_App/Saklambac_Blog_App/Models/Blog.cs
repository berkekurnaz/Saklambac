using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saklambac_Blog_App.Models
{
    public class Blog
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Photo { get; set; }
        public string CreatedDate { get; set; }

    }
}
