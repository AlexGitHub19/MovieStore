using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MovieStore.Domain.Abstract;

namespace MovieStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        private IMovieRepository repository;

        public NavController(IMovieRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Movies.Select(movie => movie.Category).Distinct().OrderBy(x => x);

            return PartialView("FlexMenu", categories);
        }
    }

}
