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
            _db.Movie.Add(new Data.Movie
            { Id = movie.Id, Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                CastMemberJunctions = movie.Cast(c => new Data.CastMember { Name = c }).ToList() });
            _db.SaveChanges();
        }
        public bool DeleteMovie(int id)
        {
            Data.Movie m = _db.Movie.Find(id);
            if (m != null)
            {
                _db.Movie.Remove(_db.Movie.Find(id));
                _db.SaveChanges();
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
            _db.SaveChanges();
        }

        public IEnumerable<Movie> GetAll()
        {
            // mapping logic in here
            // (we'll wind up repeating ourselves if we don't move this to a Mapper static class)
            return _db.Movie.Include(m => m.CastMemberJunctions).ThenInclude(j => j.CastMember).Select(m => new Movie
            {
                Id = m.Id,
                Title = m.Title,
                ReleaseDate = m.ReleaseDate,
                Cast = m.CastMembers.Select(c => c.Name).ToList()
            });
            // deferred execution - no network access / iteration yet
        }

        public IEnumerable<Movie> GetAllByCastMember(string cast)
        {
            return _db.CastMember
                .Include(c => c.MovieJunctions)
                .ThenInclude(j => j.Movie) // fills in navigation property of a navigation property
                .ThenInclude(m => m.CastMemberJunctions)
                .ThenInclude(j => j.CastMember)
                .Where(c => c.Name == cast)
                .SelectMany(c => c.MovieJunctions.Select(j => Map(j.Movie)));
            //selectMany is a version of Select that produces _multiple_ things from each element,
            //  then flattens the result to one overall list
            // deffered execution - no network access / iteration yet
            //{
            //    Id = c.Movie.Id,
            //    Title = c.Movie.Title,
            //    Cast = c.Movie.CastMembers.Select(c2 => c2.Name).ToList()
            //});
            // deferred execution - no network access / iteration yet
        }



        public Movie GetById(int id)
        {
            Data.Movie m = _db.Movie.Include(b=> b.CastMembers).First(a => a.Id == id);
            return new Movie
            { Id = m.Id, Title = m.Title, ReleaseDate = m.ReleaseDate, Cast = m.CastMembers.Select(a => a.Name).ToList() };
        }

        public static Movie Map(Data.Movie data)
        {
            return new Movie
            {
                Id = data.Id,
                Title = data.Title,
                ReleaseDate = data.ReleaseDate,
                Cast = 
            }
        }

        //public static Data.Movie Map(Movie ui)
        //{
        //    return new Data.Movie
        //    {
        //        Id = ui.Id,
        //        Title = ui.Title,
        //        ReleaseDate = ui.ReleaseDate,
        //        CastMember = ui.Cast.Select(c => _db.CastMember.FirstOrDefault(c => c.Name)).ToList()
        //    };
        //}
    }
}
