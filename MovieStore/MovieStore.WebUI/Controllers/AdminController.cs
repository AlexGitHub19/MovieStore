using System.Web.Mvc;
using MovieStore.Domain.Abstract;
using MovieStore.Domain.Entities;
using System.Linq;
using System.Web;

namespace MovieStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IMovieRepository repository;

        public AdminController(IMovieRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Movies);
        }

        public ViewResult Edit(int movieId)
        {
            Movie movie = repository.Movies.FirstOrDefault(m => m.MovieId == movieId);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    movie.ImageMimeType = image.ContentType;
                    movie.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(movie.ImageData, 0, image.ContentLength);
                }
                repository.SaveMovie(movie);
                TempData["message"] = string.Format("Changing  \"{0}\" was saved", movie.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(movie);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Movie());
        }

        [HttpPost]
        public ActionResult Delete(int movieId)
        {
            Movie deletedMovie = repository.DeleteMovie(movieId);
            if (deletedMovie != null)
            {
                TempData["message"] = string.Format("Movie \"{0}\" was deleted", deletedMovie.Name);
            }
            return RedirectToAction("Index");
        }

    }
}