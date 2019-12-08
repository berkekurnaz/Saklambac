using Saklambac_Movies_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saklambac_Movies_App.ViewModels
{
    public class MainViewModel
    {
        public List<Movie> NewMovies { get; set; }
        public List<Movie> TopMovies { get; set; }
        public List<Director> TopDirectors { get; set; }
    }
}