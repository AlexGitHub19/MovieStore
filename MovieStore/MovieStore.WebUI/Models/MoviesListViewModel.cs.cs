using System.Collections.Generic;
using MovieStore.Domain.Entities;

namespace MovieStore.WebUI.Models
{
    public class MovieListViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}