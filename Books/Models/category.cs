using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte id { get; set; }
        [Required]
        [MaxLength(122,ErrorMessage ="sss")]
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}