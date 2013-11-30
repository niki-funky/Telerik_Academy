namespace LibrarySystem.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}