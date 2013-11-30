using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LizardmanCinemas.Models;

namespace LizardmanCinemas.Data
{
    public class UowData : IUowData
    {
        private readonly DataContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        
        public UowData()
            : this(new DataContext())
        {
        }

        public UowData(DataContext context)
        {
            this.context = context;
        }
        
        public IRepository<Movie> Movies
        {
            get
            {
                return this.GetRepository<Movie>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<Actor> Actors
        {
            get
            {
                return this.GetRepository<Actor>();
            }
        }

        public IRepository<Director> Directors
        {
            get
            {
                return this.GetRepository<Director>();
            }
        }

        public IRepository<Country> Country
        {
            get
            {
                return this.GetRepository<Country>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Vote> Votes
        {
            get
            {
                return this.GetRepository<Vote>();
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        public int SaveChanges()
        {
            try
            {
                return this.context.SaveChanges();
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public DbContext GetContext()
        {
            return this.context;
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
