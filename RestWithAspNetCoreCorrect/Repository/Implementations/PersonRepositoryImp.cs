using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestWithAspNetCore.Model;
using RestWithAspNetCore.Model.Context;

namespace RestWithAspNetCore.Repository.Implementations
{
    public class PersonRepositoryImp : IPersonRepository
    {
        private MysqlContext __repository;        

        public PersonRepositoryImp(MysqlContext context)
        {
            __repository = context;
        }

        public Person Create(Person person)
        {
            try
            {
                __repository.Add(person);
                __repository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        public void Delete(long id)
        {
            var result = __repository.Persons.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if (result != null)
                    __repository.Persons.Remove(result);
                __repository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Person> FindAll()
        {
            return __repository.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return __repository.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return null;

            var result = __repository.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            try
            {
                __repository.Entry(result).CurrentValues.SetValues(person);
                __repository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        public bool Exist(long? id)
        {
            return __repository.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
