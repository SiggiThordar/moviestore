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
    
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private DbReview rDb;
        private DbUser uDb;

        public UserController()
        {
            rDb = new DbReview();
            uDb = new DbUser();
        }

        [HttpPost]
        [Route("review")]
        public void PostReview(ReviewDTO r)
        {
            r.Timestamp = DateTime.Now;
            r.CustomerUsername =  uDb.GetUserInfo(User.Identity.Name).FullName;
            rDb.AddReview(r);
        }
        [HttpGet]
        [Route("admin/users/{id}")]
        public UserDTO GetUserInfo(string id)
        {
            if (!User.IsInRole("admin"))
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            return uDb.GetUserInfo(id);
        }

    }
}
