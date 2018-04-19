using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.Models
{
    public class MovieIndexSearch
    {
        public List<Movie> movies;
        public List<string> genres;
        public string movieGenre { get; set; }

    }
}