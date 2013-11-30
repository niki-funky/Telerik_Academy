namespace LibrarySystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq.Expressions;

    public partial class Book
    {
        [ScaffoldColumn(false)]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public string ISBN { get; set; }
        public string WebSite { get; set; }
        //[Column(TypeName = "ntext")]
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}