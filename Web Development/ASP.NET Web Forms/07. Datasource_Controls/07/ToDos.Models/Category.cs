namespace ToDos.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Category
    {
        public Category()
        {
            this.Todoes = new HashSet<Todo>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Todo> Todoes { get; set; }
    }
}