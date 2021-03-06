﻿using System;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MovieDTO> GetAllMovies()
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



        public void AddMovie(MovieDTO m)
        {
            // do data check;
            var movie = new Movie { Title = m.Title, Genre = m.Genre, About = m.About, Rating = m.Rating };
            _db.Movie.Add(movie);
            _db.SaveChanges();
        }

        public void DeleteMovie(MovieDTO m)
        {

        }

        

    }
}