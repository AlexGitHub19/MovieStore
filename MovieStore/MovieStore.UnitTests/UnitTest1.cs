using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieStore.Domain.Abstract;
using MovieStore.Domain.Entities;
using MovieStore.WebUI.Controllers;

namespace MovieStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void Can_Paginate()
        //{
        //    // Организация (arrange)
        //    Mock<IMovieRepository> mock = new Mock<IMovieRepository>();
        //    mock.Setup(m => m.Movies).Returns(new List<Movie>
        //    {
        //        new Movie { MovieId = 1, Name = "Movie"},
        //        new Movie { MovieId = 2, Name = "Movie2"},
        //        new Movie { MovieId = 3, Name = "Movie3"},
        //        new Movie { MovieId = 4, Name = "Movie4"},
        //        new Movie { MovieId = 5, Name = "Movie5"}
        //    });
        //    MovieController controller = new MovieController(mock.Object);
        //    controller.pageSize = 3;

        //    // Действие (act)
        //    IEnumerable<Movie> result = (IEnumerable<Movie>)controller.List(2).Model;

        //    // Утверждение (assert)
        //    List<Movie> movies = result.ToList();
        //    Assert.IsTrue(movies.Count == 2);
        //    Assert.AreEqual(movies[0].Name, "Movie4");
        //    Assert.AreEqual(movies[1].Name, "Movie5");
        //}
    }
}
