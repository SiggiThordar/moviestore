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
        private MovieStoreEntities _db;

        public DbUser()
        {
            _db = new MovieStoreEntities();
        }


        //Hér sækir hann notanda í gagnagrunninum og sendir í UserController sem birtir það svo.
        public UserDTO GetUserInfo(string id)
        {
            return (from x in _db.AspNetUsers
                    where x.UserName == id
                    select new UserDTO
                    {
                        FullName = x.FullName,
                        Address = x.Address,
                        Phone = x.Phone
                    }).SingleOrDefault();
        }
    }
}