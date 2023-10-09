using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsTest.LIBRARY.Models.Movies
{
    public class Movie
    {
        public string Id { get; set; }
        public MovieImage PrimaryImage { get; set; }
        public MovieTitle TitleText { get; set; }  
        public MovieReleaseDate ReleaseDate { get; set; }
        public MoviePlot Plot { get; set; }
        public MovieRuntime Runtime { get; set; }


    }
}
