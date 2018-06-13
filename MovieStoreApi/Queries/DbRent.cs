using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieStoreApi.Models.EF;
using MovieStoreApi.Models.DTO;

namespace MovieStoreApi.Queries
{
    public class DbRent
    {
        private MovieStoreEntities _db;

        public DbRent()
        {
            _db = new MovieStoreEntities();
        }


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
        

        public void RentMovieById(int id, string UserName)
        {
            var movie = GetMovieById(id);
            var rent = new Rent
            {
                MovieId = id,
                MovieTitle = movie.Title,
                UserId = UserName
            };

            _db.Rent.Add(rent);

            _db.SaveChanges();
        }

        

        public IEnumerable<RentDTO> GetAllRentsByUserName(string UserName)
        {
            var rentList = (from x in _db.Rent
                             where x.UserId == UserName
                             select x);

            return ListRentToDTO(rentList);
        }

        // PrivateFunctions
        private IEnumerable<RentDTO> ListRentToDTO(IEnumerable<Rent> r)
        {
            var rentListDto = new List<RentDTO>();
            foreach (var item in r)
            {
                rentListDto.Add(RentToDTO(item));
            }

            return rentListDto;
        }

        private RentDTO RentToDTO(Rent r)
        {
            return new RentDTO
            {
                Id = r.Id,
                MovieId = r.MovieId,
                MovieTitle = r.MovieTitle,
                UserId = r.UserId
            };
        }
    }
}