using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestWithAspNetCore.Model;
using RestWithAspNetCore.Model.Context;
using RestWithAspNetCore.Repository;

namespace RestWithAspNetCore.Business.Implementations
{
    public class PersonBusinessImp : IPersonBusiness
    {
        private IPersonRepository _repository;

        public PersonBusinessImp(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}
