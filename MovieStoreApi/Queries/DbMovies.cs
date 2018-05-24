using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieStoreApi.Models.EF;
using MovieStoreApi.Models.DTO;


namespace MovieStoreApi.Queries
{
    public class DbMovies
    {
        private MovieStoreEntities _db;

        public DbMovies()
        {
            _db = new MovieStoreEntities();
        }

        public IEnumerable<MovieDTO> GetMovies()
        {
            return (from x in _db.Movie
                    select new MovieDTO
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Genre = x.Genre,
                        About = x.About,
                        Rating = x.Rating
                    });
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieDTO GetMovieById(int id)
        {
            return (from x in _db.Movie
                    where x.Id == id
                    select new MovieDTO
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Genre = x.Genre,
                        About = x.About,
                        Rating = x.Rating
                    }).SingleOrDefault();
        }

        //public void RentMovieById(int id, string userName)
        //{
        //    var movie = GetMovieById(id);
        //    var subscribe = new Subscribe
        //    {

        //    }
        //}
    }
}