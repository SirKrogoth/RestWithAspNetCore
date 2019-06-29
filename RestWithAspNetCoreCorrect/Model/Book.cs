using RestWithAspNetCoreCorrect.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetCoreCorrect.Model
{
    public class Book : BaseEntity
    {        
        public string title { get; set; }
        public string author { get; set; }
        public decimal price { get; set; }
        public DateTime launchDate { get; set; }
    }
}
