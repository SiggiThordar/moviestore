using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStoreApi.Models.DTO
{
    public class RentDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }

    }
}