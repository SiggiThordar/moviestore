using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieStoreApi.Models.EF;
using MovieStoreApi.Models.DTO;

namespace MovieStoreApi.Queries
{
    public class DbUser
    {
        private MovieStoreEntities db;

        public DbUser()
        {
            db = new MovieStoreEntities();
        }

        public UserDTO GetUserInfo(string id)
        {
            return (from x in db.AspNetUsers
                    where x.UserName == id
                    select new UserDTO
                    {
                        FullName = x.FullName
                    }).SingleOrDefault();
        }
    }
}