using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// namespace alias to get around same-name classes
using Data = MVCDemo.DataAccess;    // now, we have Data.Movie
using MVCDemo.Models;                //  and just Movie for this one
using Microsoft.EntityFrameworkCore;

namespace MVCDemo.Repositories
{
    public class MovieRepoDB : IMovieRepo
    {
        private readonly Data.MovieDBContext _db;

        public MovieRepoDB(Data.MovieDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            // code-first style, make sure the database exists by now.
            db.Database.EnsureCreated();
        }

        public void CreateMovie(Movie movie)
        {
            _db.Movie.Add(new Data.Movie { Id = movie.Id, Title = movie.Title, ReleaseDate = movie.ReleaseDate,
                CastMembers = movie.Cast.Select(c => new Data.CastMember { Name = c }).ToList() });
        }
        public bool DeleteMovie(int id)
        {
            Data.Movie m = _db.Movie.Find(id);
            if (m != null)
            {
                _db.Movie.Remove(_db.Movie.Find(id));
                return true;
            }
            return false;
        }
        public void EditMovie(Movie movie)
        {
            _db.Entry(_db.Movie.Find(movie.Id)).CurrentValues.SetValues(new Data.Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                CastMembers = movie.Cast.Select(c => new Data.CastMember { Name = c }).ToList()
            }
            );
        }

        public IEnumerable<Movie> GetAll()
        {
            // mapping logic in here
            // (we'll wind up repeating ourselves if we don't move this to a Mapper static class)
            return _db.Movie.Include(m => m.CastMembers).Select(m => new Movie
            {
                Id = m.Id,
                Title = m.Title,
                Cast = m.CastMembers.Select(c => c.Name).ToList()
            });
            // deferred execution - no network access / iteration yet
        }

        public Movie GetById(int id) => throw new NotImplementedException();
    }
}
