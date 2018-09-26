using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace laba2.Models
{
    public class ImageContext : DbContext
    {
        public ImageContext() : base("DefaultConnection")
        {

        }

        public DbSet<Image> Images { get; set; }
    }
}