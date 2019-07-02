using RestWithAspNetCore.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithAspNetCore.Model;
using RestWithAspNetCoreCorrect.Data.Converter;

namespace RestWithAspNetCoreCorrect.Data.Converters
{
    public class PersonConverter : IParcer<PersonVO, Person>, IParcer<Person, PersonVO>
    {
        public PersonVO Parce(Person origin)
        {
            if (origin == null) return new PersonVO();

            return new PersonVO
            {
                id = origin.id,
                Address = origin.Address,
                FirstName = origin.FirstName,
                Gender = origin.Gender,
                LastName = origin.LastName
            };
        }

        public Person Parce(PersonVO origin)
        {
            if (origin == null) return new Person();

            return new Person
            {
                id = Convert.ToInt64(origin.id),
                Address = origin.Address,
                FirstName = origin.FirstName,
                Gender = origin.Gender,
                LastName = origin.LastName
            };
        } 

        public List<Person> ParceList(List<PersonVO> origin)
        {
            if (origin == null) return new List<Person>();

            return origin.Select(item => Parce(item)).ToList();
        }

        public List<PersonVO> ParceList(List<Person> origin)
        {
            if(origin == null) return new List<PersonVO>();

            return origin.Select(item => Parce(item)).ToList();
        }        
    }
}
