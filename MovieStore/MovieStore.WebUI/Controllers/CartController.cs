using System.Linq;
using System.Web.Mvc;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Abstract;
using MovieStore.WebUI.Models;

namespace GameStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IMovieRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController(IMovieRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }



        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel {Cart = cart, ReturnUrl = returnUrl} );
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public RedirectToRouteResult AddToCart(Cart cart, int movieId, string returnUrl)
        {
            Movie movie = repository.Movies.FirstOrDefault(m => m.MovieId == movieId);

            if (movie != null)
            {
                cart.AddItem(movie, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int movieId, string returnUrl)
        {
            Movie movie = repository.Movies.FirstOrDefault(m => m.MovieId == movieId);

            if (movie != null)
            {
                cart.RemoveLine(movie);
            }
            return RedirectToAction("Index", new { returnUrl });
        }



    }
}