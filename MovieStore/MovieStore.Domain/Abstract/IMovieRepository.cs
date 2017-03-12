using System.Collections.Generic;
using MovieStore.Domain.Entities;

namespace MovieStore.Domain.Abstract
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Movies { get; }
        void SaveMovie(Movie movie);
        Movie DeleteMovie(int movieId);
    }
}