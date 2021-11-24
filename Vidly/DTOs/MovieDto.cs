using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTOs
{
    public class MovieDto
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime dateAdded { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Number In Stock Must Be Between 1 to 20")]
        public byte numberInStock { get; set; }
        public byte numberAvailable { get; set; }

        public MovieDto()
        {
            dateAdded = DateTime.Now;
        }
    }
}