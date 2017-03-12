using System.Collections.Generic;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Abstract;

namespace MovieStore.Domain.Concrete
{
    public class EFMovieRepository : IMovieRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Movie> Movies
        {
            get { return context.Movies; }
        }

        public void SaveMovie(Movie movie)
        {
            if (movie.MovieId == 0)
            {
                context.Movies.Add(movie);
            }
            else
            {
                Movie dbEntry = context.Movies.Find(movie.MovieId);
                if (dbEntry != null)
                {
                    dbEntry.Name = movie.Name;
                    dbEntry.Description = movie.Description;
                    dbEntry.Price = movie.Price;
                    dbEntry.Category = movie.Category;
                    dbEntry.ImageData = movie.ImageData;
                    dbEntry.ImageMimeType = movie.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public Movie DeleteMovie(int movieId)
        {
            Movie dbEntry = context.Movies.Find(movieId);
            if (dbEntry != null)
            {
                context.Movies.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
