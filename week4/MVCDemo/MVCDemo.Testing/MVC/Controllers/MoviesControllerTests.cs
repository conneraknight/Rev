using Moq;
using MVCDemo.Controllers;
using MVCDemo.Models;
using MVCDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MVCDemo.Testing.MVC.Controllers
{
    // unit testing with fakes is "correct" but cumbersome.
    // mocks to the rescue
    //public class FakeMovieRepo : IMovieRepo
    //{
    //    public void CreateMovie(Movie movie)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool DeleteMovie(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void EditMovie(Movie movie)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Movie> GetAll()
    //    {
    //        return new List<Movie> {
    //                new Movie
    //                {
    //                    Id = 1, Title = "Star Wars"
    //                }
    //        };
    //    }

    //    public IEnumerable<Movie> GetAllByCastMember(string cast)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Movie GetById(int id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class MoviesControllerTests
    {
        // tests that when the repository has movies to give,
        // we'll get an index view with a model (ienumerable<movie>) containing those movies
        [Fact]
        public void IndexWithMoviesHasMovies()
        {
            //arrange
            //  var db = new MoviesDBContext(); // in-memory
            //  var repo = new MovieRepoDB()
            //  var controller = new MoviesController():
            // at this point we are not really doing a unit test.
            // this is really more like an integration test.
            // to unit tests something like MVC, that uses dependency injection,
            // or really in general, to unit test something with complex(or any) dependencies
            // we will use mocking (with the Moq framework)

            //if we didn't have a mocking framework, we would have to do stuff like this
            var fakeRepo = new FakeMovieRepo();
            var controller = new MoviesController(fakeRepo);
            //because I used dependency inversion (my controller depends on an interface,
            //not a concrete class) I am able to provide a different implementation
            // without breaking or changing the controller.

            //dependency injection is what you call it when a framework automatically constructs
            // objects requested as constructor parameters

            Mock<IMovieRepo> mockRepo = new Mock<IMovieRepo>();
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(new List<>)
            //act

            //assert
        }
    }
}
