using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using LibrarySystem.Models;

namespace LibrarySystem.ViewModels
{
    public class BookVM
    {
        public static Expression<Func<Book, BookVM>> FromBook
        {
            get
            {
                return book => new BookVM
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    Authors = book.Authors,
                    CategoryName = book.Category.Name,
                    Category = new CategoryVM()
                    {
                        CategoryId = book.Category.CategoryId,
                        Name = book.Category.Name
                    },
                    Description = book.Description,
                    ISBN = book.ISBN,
                    WebSite = book.WebSite
                };
            }
        }

        [ScaffoldColumn(false)]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public string ISBN { get; set; }
        public string WebSite { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string CategoryName { get; set; }
        [UIHint("_CategoryDropdown")]
        public CategoryVM Category { get; set; }
    }
}