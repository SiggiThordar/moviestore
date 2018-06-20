using MovieStoreApi.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieStoreApi.Models.DTO;

namespace MovieStoreApi.Controllers
{

    //[Authorize]
    [RoutePrefix("api/rent")]
    public class RentController : ApiController
    {
        private DbRent rDb;
        private DbMovies mDb;

        public RentController()
        {
            rDb = new DbRent();
            mDb = new DbMovies();
        }

        //api/rent/movie/'+id,
        [HttpGet]
        [Route("movie/{id}")]
        public void RentMovieById(int id)
        {
            rDb.RentMovieById(id, User.Identity.Name);
        }

        [HttpGet]
        [Route("user")]
        public IEnumerable<RentDTO> GetAllRentsByUser()
        {
            return rDb.GetAllRentsByUserName(User.Identity.Name);
        }
        
    }
}
