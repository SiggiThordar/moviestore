using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStoreApi.Models.DTO
{
    public class SubscribeDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public bool Subscribed { get; set; }

    }
}