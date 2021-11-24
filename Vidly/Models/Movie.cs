using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public string genre { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime dateAdded { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20, ErrorMessage = "Number In Stock Must Be Between 1 to 20")]
        public byte numberInStock { get; set; }
        public byte numberAvailable { get; set; }

        public Movie()
        {
            dateAdded = DateTime.Now;
        }
    }
}