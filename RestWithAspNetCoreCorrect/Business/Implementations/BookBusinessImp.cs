﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithAspNetCoreCorrect.Model;
using RestWithAspNetCoreCorrect.Repository;
using RestWithAspNetCoreCorrect.Repository.Generic;

namespace RestWithAspNetCoreCorrect.Business.Implementations
{
    public class BookBusinessImp : IBookBusiness
    {
        private IRepository<Book> _repository;

        public BookBusinessImp(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}