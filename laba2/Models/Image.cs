using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace laba2.Models
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public byte[] Data { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}