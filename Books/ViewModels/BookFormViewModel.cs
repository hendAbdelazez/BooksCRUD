using Books.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Books.ViewModels
{
    public class BookFormViewModel
    {

        public int id { get; set; }
        [Required]
        [MaxLength(258)]
        public string Title { get; set; }
        [Required]
        [MaxLength(258)]
        public string Author { get; set; }
        [Required]
        [MaxLength(258)]
        public string Description { get; set; }
        public byte categoryId { get; set; }
        public category Category { get; set; }
        public IEnumerable<category> categories { get; set; }

    }
}