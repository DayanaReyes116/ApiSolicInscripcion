using ApiSolicInscripcion.Core.Entities;
using ApiSolicInscripcion.Core.Interfaces.Repositories;
using ApiSolicInscripcion.Core.Models;
using System.Collections.Generic;
using System.Linq;


namespace ApiSolicInscripcion.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly SolicitudDbContext _context;

        public BaseRepository(SolicitudDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            this._context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }

        public T FindById(int id)
        {
            return this._context.Set<T>().Find(id);
        }

        public IQueryable<T> FindAll()
        {
            return this._context.Set<T>();
        }

        public void Update(T entity)
        {
            this._context.Set<T>().Update(entity);
        }
    }
}