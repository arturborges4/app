using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.Domain.Interfaces.Repositories;
using App.Persistanse;
using Microsoft.EntityFrameworkCore;

namespace App.Persistense.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public DbContext _dbContextEntity { get; set; }

        public DbSet<TEntity> _dbSetEntity { get; set; }

        public RepositoryBase(AppDbContext dbContext)
        {
            _dbContextEntity = dbContext;
            _dbContextEntity.ChangeTracker.AutoDetectChangesEnabled = false;
            _dbSetEntity = dbContext.Set<TEntity>();
        }
        public DbContext Context()
        {
            return _dbContextEntity;
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where)
        {
            return _dbSetEntity.Where(where).AsNoTracking();
        }

        public void save(TEntity obj)
        {
            if ((Guid)obj.GetType().GetProperty("Id").GetValue(obj, null) != Guid.Empty)
            {
                _dbSetEntity.Update(obj);
            }
            else
            {
                _dbSetEntity.Add(obj);
            }
        }

        public int SaveChanges()
        {
            var written = 0;
            while(written == 0)
            {
                try
                {
                    written = _dbContextEntity.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach(var entry in ex.Entries)
                    {
                        throw new NotSupportedException("Ocorreu um erro em: " + entry.Metadata.Name);
                    }
                }
            }
            return written;
        }

        public void update(TEntity obj)
        {
            _dbSetEntity.Update(obj);
        }
        public void Delete(Guid id)
        {
            var data = _dbSetEntity.Find(id);
            if(data != null)
            {
                _dbSetEntity.Remove(data);
            }
        }

        
    }
}
