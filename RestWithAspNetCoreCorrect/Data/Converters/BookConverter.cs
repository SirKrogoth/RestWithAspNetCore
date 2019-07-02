using RestWithAspNetCore.Data.VO;
using RestWithAspNetCore.Model;
using RestWithAspNetCoreCorrect.Data.Converter;
using RestWithAspNetCoreCorrect.Data.VO;
using RestWithAspNetCoreCorrect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetCoreCorrect.Data.Converters
{
    public class BookConverter : IParcer<BookVO, Book>, IParcer<Book, BookVO>
    {
        public BookVO Parce(Book origin)
        {
            if (origin == null) return new BookVO();

            return new BookVO
            {
                id = origin.id,
                author = origin.author,
                launchDate = origin.launchDate,
                price = origin.price,
                title = origin.title
            };
        }

        public Book Parce(BookVO origin)
        {
            if (origin == null) return new Book();

            return new Book
            {
                id = origin.id,
                author = origin.author,
                launchDate = origin.launchDate,
                price = origin.price,
                title = origin.title
            };
        }

        public List<Book> ParceList(List<BookVO> origin)
        {
            if (origin == null) return new List<Book>();

            return origin.Select(item => Parce(item)).ToList();
        }

        public List<BookVO> ParceList(List<Book> origin)
        {
            if (origin == null) return new List<BookVO>();

            return origin.Select(item => Parce(item)).ToList();
        }
    }
}
