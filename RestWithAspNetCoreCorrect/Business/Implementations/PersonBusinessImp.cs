using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestWithAspNetCore.Data.VO;
using RestWithAspNetCore.Model;
using RestWithAspNetCore.Model.Context;
using RestWithAspNetCoreCorrect.Data.Converters;
using RestWithAspNetCoreCorrect.Repository.Generic;

namespace RestWithAspNetCore.Business.Implementations
{
    public class PersonBusinessImp : IPersonBusiness
    {
        private IRepository<Person> _repository;

        private readonly PersonConverter _converter;

        public PersonBusinessImp(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parce(person);
            personEntity = _repository.Create(personEntity);

            return _converter.Parce(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.ParceList(_repository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parce(_repository.FindById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parce(person);
            personEntity = _repository.Update(personEntity);

            return _converter.Parce(personEntity);
        }
    }
}
