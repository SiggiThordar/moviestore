//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieStoreApi.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public string CustomerUsername { get; set; }
        public Nullable<int> MovieRating { get; set; }
        public string Critic { get; set; }
        public byte[] Timestamp { get; set; }
    }
}