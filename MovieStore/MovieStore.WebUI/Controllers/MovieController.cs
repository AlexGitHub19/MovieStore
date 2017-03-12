using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStore.Domain.Abstract;
using MovieStore.Domain.Entities;
using MovieStore.WebUI.Models;

namespace MovieStore.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private IMovieRepository repository;
        public int pageSize = 4;
        public MovieController(IMovieRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int page = 1)
        {
            MovieListViewModel model = new MovieListViewModel
            {
                Movies = repository.Movies.Where(p => category == null || p.Category == category).OrderBy(movie => movie.MovieId).Skip((page - 1) * pageSize) .Take(pageSize),
                    PagingInfo = new PagingInfo {CurrentPage = page, ItemsPerPage = pageSize,
                    TotalItems = category == null ? repository.Movies.Count(): repository.Movies.Where(movie => movie.Category == category).Count() },
                    CurrentCategory = category
            };
     
            return View(model);
        }

        public FileContentResult GetImage(int movieId)
        {
            Movie movie = repository.Movies.FirstOrDefault(m => m.MovieId == movieId);

            if (movie != null)
            {
                return File(movie.ImageData, movie.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

    }
}
