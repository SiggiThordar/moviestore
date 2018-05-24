using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieStoreApi.Models.DTO;
using MovieStoreApi.Queries;


namespace MovieStoreApi.Controllers
{
    [RoutePrefix("api/movie")]
    public class MovieController : ApiController
    {
        private DbMovies _q;

        public MovieController()
        {
            _q = new DbMovies();
        }

        [HttpGet]
        [Route("movies")]
        public IEnumerable<MovieDTO> GetMovies()
        {
            return _q.GetMovies();
        }

        [HttpGet]
        [Route("movies/{id}")]
        public MovieDTO GetMovieById(int id)
        {
            return _q.GetMovieById(id);
        }

        //[HttpGet]
        //[Route("movies/rent/{id}")]
        //public void RentMoviebyId(int id)
        //{
        //    _q.RentMovieById(id, User.Identity.Title)
        //}



    }
}
