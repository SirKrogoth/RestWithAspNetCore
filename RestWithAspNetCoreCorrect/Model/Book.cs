using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetCoreCorrect.Model
{
    public class Book
    {
        [Key]
        [Column("id")]
        public string id { get; set; }
        public string title { get; set; }
        public string autor { get; set; }
        public decimal price { get; set; }
        public DateTime launchDate { get; set; }
    }
}
