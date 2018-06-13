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
    [RoutePrefix("api/movies")]
    public class MovieController : ApiController
    {
        private DbMovies mDb;

        public MovieController()
        {
            mDb = new DbMovies();
        }

        [HttpGet]
        [Route("allmovies")]
        public IEnumerable<MovieDTO> GetMovies()
        {
            return mDb.GetAllMovies();
        }

        [HttpGet]
        [Route("review/{id}")]
        public MovieDTO GetMovieById(int id)
        {
            return mDb.GetMovieById(id);
        }

        


        /// <summary>
        /// Þú getur addað mynd ef þú ert admin
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

            mDb.AddMovie(m);
        }

        [HttpDelete]
        [Route("admin/movie")]
        public void DeleteMovie(MovieDTO m)
        {
            if (!User.IsInRole("admin"))
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            mDb.AddMovie(m);
        }

    }
}
