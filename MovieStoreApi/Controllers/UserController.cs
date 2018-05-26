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
        private DbReview db;
        private DbUser uDb;

        public UserController()
        {
            db = new DbReview();
            uDb = new DbUser();
        }

        [HttpPost]
        [Route("review")]
        public void PostReview(ReviewDTO r)
        {
            r.Timestamp = DateTime.Now;
            r.CustomerUsername =  uDb.GetUserInfo(User.Identity.Name).FullName;
            db.AddReview(r);
        }

    }
}
