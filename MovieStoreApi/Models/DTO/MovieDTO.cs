using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStoreApi.Models.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string About { get; set; }
        public int? Rating { get; set; }

    }
}