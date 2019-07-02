using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetCoreCorrect.Data.Converter
{
    public interface IParcer<O, D>
    {
        D Parce(O origin);
        List<D> ParceList(List<O> origin);
    }
}
