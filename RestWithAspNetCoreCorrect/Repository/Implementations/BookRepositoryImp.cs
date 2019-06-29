using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithAspNetCore.Model.Context;
using RestWithAspNetCoreCorrect.Model;

namespace RestWithAspNetCoreCorrect.Repository.Implementations
{    
    public class BookRepositoryImp : IBookRepository
    {
        private MysqlContext _repository;

        public BookRepositoryImp(MysqlContext context)
        {
            _repository = context;
        }

        public Book Create(Book book)
        {
            try
            {
                _repository.Add(book);
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return book;
        }

        public void Delete(long id)
        {
            var result = _repository.Books.SingleOrDefault(p => p.id.Equals(id));

            try
            {
                if (result != null)
                    _repository.Books.Remove(result);
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Book> FindAll()
        {
            return _repository.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _repository.Books.SingleOrDefault(p => p.id.Equals(id));
        }

        public Book Update(Book book)
        {
            if (!Exist(book.id)) return null;

            var result = _repository.Books.SingleOrDefault(p => p.id.Equals(book.id));

            try
            {
                _repository.Entry(result).CurrentValues.SetValues(book);
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return book;
        }

        private bool Exist(string id)
        {
            return _repository.Books.Any(p => p.id.Equals(id));
        }
    }
}
