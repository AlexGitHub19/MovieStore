using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Domain.Entities
{
    public class Movie
    {
        [HiddenInput(DisplayValue = false)]
        public int MovieId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please, enter name of movie")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please, enter description of movie")]
        public string Description { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please, enter category of movie")]
        public string Category { get; set; }

        [Display(Name = "Price ($)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please, enter a positive value of price ")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
