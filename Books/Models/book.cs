using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Books.Models
{
    public class book
    {
        public int id { get; set; }
        [Required]
        [MaxLength(258)]
        public string Title { get; set; }
        [Required]
        [MaxLength(126)]
        
        public string Author { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        public byte categoryId { get; set; }
        public category Category { get; set; }
        public DateTime Addon { get; set; }
        public book()
        {
            Addon = DateTime.Now;
        }
    }
} 