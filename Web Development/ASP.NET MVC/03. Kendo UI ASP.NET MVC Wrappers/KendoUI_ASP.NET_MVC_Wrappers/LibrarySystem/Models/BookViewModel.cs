using System;
using System.Linq.Expressions;

namespace LibrarySystem.Models
{
    public class BookViewModel
    {
        public static Expression<Func<Book, BookViewModel>> FromBook
        {
            get
            {
                return book => new BookViewModel
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    Authors = book.Authors,
                    CategoryName = book.Category.Name
                };
            }
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public string CategoryName { get; set; }
    }
}