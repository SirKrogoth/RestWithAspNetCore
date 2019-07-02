using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetCoreCorrect.Data.VO
{
    public class BookVO
    {
        public long id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public decimal price { get; set; }
        public DateTime launchDate { get; set; }
    }
}
