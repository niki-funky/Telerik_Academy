namespace ToDos.Models
{
    using System;
    using System.Collections.Generic;

    public class Todo
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Nullable<System.DateTime> LastChangeDate { get; set; }

        public virtual Category Category { get; set; }
    }
}