﻿using System;
using System.Collections.Generic;
using System.Threading;
using RestWithAspNetCore.Model;

namespace RestWithAspNetCore.Services.Implementations
{
    public class PersonServiceImp : IPersonService
    {
        //contador responsável por gerar um fake id, pois nao estamos acessando banco de dados.
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name " + i,
                LastName = "Person LastName " + i,
                Adress = "Adress " + i,
                Gender = "Gender " + i
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = id,
                FirstName = "Person Name " + id,
                LastName = "Person LastName " + id,
                Adress = "Adress " + id,
                Gender = "Gender " + id
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
