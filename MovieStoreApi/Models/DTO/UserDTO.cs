using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStoreApi.Models.DTO
{
    public class UserDTO
    {        
        public string FullName { get; set; }        
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}