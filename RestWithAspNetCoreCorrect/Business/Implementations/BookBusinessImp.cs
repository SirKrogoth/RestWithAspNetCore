using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithAspNetCoreCorrect.Data.Converters;
using RestWithAspNetCoreCorrect.Data.VO;
using RestWithAspNetCoreCorrect.Model;
using RestWithAspNetCoreCorrect.Repository;
using RestWithAspNetCoreCorrect.Repository.Generic;

namespace RestWithAspNetCoreCorrect.Business.Implementations
{
    public class BookBusinessImp : IBookBusiness
    {
        private IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBusinessImp(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parce(book);
            bookEntity = _repository.Create(bookEntity);

            return _converter.Parce(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.ParceList(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parce(_repository.FindById(id));
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parce(book);
            bookEntity = _repository.Update(bookEntity);

            return _converter.Parce(bookEntity);
        }
    }
}
