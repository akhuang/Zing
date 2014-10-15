using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zing.Data;
using Zing.Logging;
using Zing.Utility.Extensions;
using Zing.UI.Navigation;

namespace Zing
{
    public class ServiceBase<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _rep;

        public ILogger Logger { get; set; }

        public ServiceBase(IRepository<T> rep)
        {
            _rep = rep;
            Logger = NullLogger.Instance;
        }
        public void Create(T entity)
        {
            _rep.Create(entity);
        }

        public void Update(T entity)
        {
            _rep.Update(entity);
        }

        public void Delete(T entity)
        {
            _rep.Delete(entity);
        }

        public void Copy(T source, T target)
        {
            _rep.Copy(source, target);
        }

        public void Flush()
        {
            _rep.Flush();
        }

        public T Get(int id)
        {
            return _rep.Get(id);
        }
        public T Get()
        {
            return _rep.Get();
        }
        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _rep.Get(predicate);
        }

        public IQueryable<T> Table
        {
            get { return _rep.Table; }
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return _rep.Count(predicate);
        }

        public IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate)
        {
            return _rep.Fetch(predicate);
        }


        public IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order)
        {
            return Fetch(predicate, order).ToReadOnlyCollection();
        }

        public IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order, int skip, int count)
        {
            return _rep.Fetch(predicate, order, skip, count).ToReadOnlyCollection();
        }

        #region IService<T> Members


        public IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order, Pagination pagination)
        {
            return _rep.Fetch(predicate, order, pagination.GetStartIndex(), pagination.PageSize).ToReadOnlyCollection();
        }

        #endregion
    }
}
