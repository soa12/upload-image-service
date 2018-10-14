using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace laba2.Models
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Название")]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [DisplayName("Описание")]
        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(200)]
        public string PathToPhoto { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}