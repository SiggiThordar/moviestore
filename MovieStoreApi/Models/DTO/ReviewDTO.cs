using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStoreApi.Models.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public string CustomerUsername { get; set; }
        public int MovieRating { get; set; }
        public string Critic { get; set; }
        public DateTime Timestamp { get; set; }

    }
}