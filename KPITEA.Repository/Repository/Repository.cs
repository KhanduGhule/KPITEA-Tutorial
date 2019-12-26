using KPITEA.Repository.Interface;
using KPITEA.Repository.ModelEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KPITEA.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        //private readonly MultilayerDbContext _context;
        //private IDbSet<T> _dbSet;

        //public Repository(MultilayerDbContext context)
        //{
        //    _context = context;
        //    this._dbSet = _context.Set<T>();
        //}

        private readonly KPITEAEntities _context;
        private IDbSet<T> _dbSet;

        public Repository(KPITEAEntities context)
        {
            _context = context;
            this._dbSet = _context.Set<T>();
        }


        protected virtual IDbSet<T> DbSet
        {
            get { return _dbSet ?? (_dbSet = _context.Set<T>()); }
        }

        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.DbSet.Add(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var fail = GenerateException(dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                if (_context.Entry(entity).State == EntityState.Detached)
                    DbSet.Attach(entity);

                this.DbSet.Remove(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var fail = GenerateException(dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                DbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var fail = GenerateException(dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public virtual IQueryable<T> GetAll
        {
            get { return DbSet; }
        }

        public virtual IQueryable<T> GetAllNoTracking
        {
            get { return DbSet.AsNoTracking(); }
        }

        public virtual IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includedProperties)
        {
            var entities = DbSet.AsQueryable();
            foreach (var includedPropery in includedProperties)
            {
                entities = entities.Include(includedPropery);
            }

            return entities;
        }

        public virtual IQueryable<T> GetAllIncluding(string includedProperties, Boolean EnableTacking = false)
        {
            var entities = DbSet.AsQueryable();
            var relations = includedProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var property in relations)
            {
                entities = entities.Include(property);
            }
            if (EnableTacking)
                return entities;
            else
                return entities.AsNoTracking();
        }

        public virtual T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        //public DbRawSqlQuery<T> GetWithRawSql<T>(string sql, params object[] parameters)
        //{
        //    return Context.Database.SqlQuery<T>(sql, parameters);
        //}

        public virtual IQueryable<T> GetWithRawSql(string query, params object[] parameters)
        {
            return _context.Database.SqlQuery<T>(query, parameters).AsQueryable();
            //return this.DbSet.SqlQuery(query, parameters).ToList();
        }
        public virtual IQueryable<T> ExecProcedureWithParam(string query, params object[] parameters)
        {
            return _context.Database.SqlQuery<T>(query, parameters).AsQueryable();
            //return this.DbSet.SqlQuery(query, parameters).ToList();
        }
        public virtual IQueryable<T> ExecProcedure(string query)
        {
            return _context.Database.SqlQuery<T>(query).AsQueryable();
            //return this.DbSet.SqlQuery(query, parameters).ToList();
        }

        private static Exception GenerateException(DbEntityValidationException dbEx)
        {
            var msg = string.Empty;

            foreach (var validationErrors in dbEx.EntityValidationErrors)
                foreach (var validationError in validationErrors.ValidationErrors)
                    msg += Environment.NewLine +
                           string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

            var fail = new Exception(msg, dbEx);
            return fail;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

    }
}
