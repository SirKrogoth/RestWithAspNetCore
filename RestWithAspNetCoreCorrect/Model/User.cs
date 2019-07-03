using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetCoreCorrect.Model
{
    public class User
    {
        public long? id { get; set; }
        public string login { get; set; }
        public string accessKey { get; set; }
    }
}
