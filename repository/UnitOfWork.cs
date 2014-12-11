using System;
using System.Collections.Generic;

namespace repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly LocalReportingEntities context;
        private bool disposed;
        private Dictionary<string, object> repositories;

        public UnitOfWork(LocalReportingEntities context)
        {
            this.context = context;
        }

        public UnitOfWork()
        {
            context = new LocalReportingEntities();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public CategoryRepository GetCategoryRepository()
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }
            var type = "category";
            if (!repositories.ContainsKey(type))
            {
                CategoryRepository repositoryInstance = new CategoryRepository(context);
                repositories.Add(type, repositoryInstance);
            }
            return (CategoryRepository) repositories[type];
        }

        public EventRepository GetEventRepository()
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }
            var type = "event";
            if (!repositories.ContainsKey(type))
            {
                EventRepository repositoryInstance = new EventRepository(context);
                repositories.Add(type, repositoryInstance);
            }
            return (EventRepository)repositories[type];
        }
    }
}
