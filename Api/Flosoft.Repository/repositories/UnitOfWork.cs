using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading.Tasks;

namespace Flowsoft.Repository.repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public void ChangeDatabase(string database)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int SaveChanges(bool ensureAutoHistory = false)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(bool ensureAutoHistory = false)
        {
            throw new NotImplementedException();
        }

        public void TrackGraph(object rootEntity, Action<EntityEntryGraphNode> callback)
        {
            throw new NotImplementedException();
        }
    }
}
