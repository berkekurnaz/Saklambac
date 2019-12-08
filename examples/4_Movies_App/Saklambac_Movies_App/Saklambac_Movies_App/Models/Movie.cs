using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saklambac_Movies_App.Models
{
    public class Movie
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImdbScore { get; set; }
        public string Photo { get; set; }
        public string DirectorId { get; set; }

    }
}