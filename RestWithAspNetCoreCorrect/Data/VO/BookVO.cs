using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RestWithAspNetCoreCorrect.Data.VO
{
    //Server para exibir na orgem que desejarmos a serialização dos dados.
    [DataContract]
    public class BookVO
    {
        //[DataMember(Order = 1, Name = "codigo")]
        [DataMember(Order = 1)]
        public long id { get; set; }
        [DataMember(Order = 2)]
        public string title { get; set; }
        [DataMember(Order = 3)]
        public string author { get; set; }
        [DataMember(Order = 5)]
        public decimal price { get; set; }
        [DataMember(Order = 4)]
        public DateTime launchDate { get; set; }
    }
}
