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
    [RoutePrefix("api/moviestore")]
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
            return _q.GetAllMovies();
        }

        [HttpGet]
        [Route("movies/{id}")]
        public MovieDTO GetMovieById(int id)
        {
            return _q.GetMovieById(id);
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        [HttpPost]
        [Route("admin/movie")]
        public void AddMovie(MovieDTO m)
        {
            if (!User.IsInRole("admin"))
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            _q.AddMovie(m);
        }


    }
}
