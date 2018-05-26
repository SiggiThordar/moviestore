using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieStoreApi.Models.EF;
using MovieStoreApi.Models.DTO;

namespace MovieStoreApi.Queries
{
    public class DbReview
    {
        private MovieStoreEntities db;

        public DbReview()
        {
            db = new MovieStoreEntities();
        }

        public void AddReview(ReviewDTO r)
        {
            var k = 1; 

        }
    }
}