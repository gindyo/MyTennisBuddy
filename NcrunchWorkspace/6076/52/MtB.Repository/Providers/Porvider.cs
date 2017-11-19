using System.Linq;
using System.Linq.Expressions;

namespace MtB.Repository.Providers
{
    public class Porvider<T> : IQueryProvider
    {
        public Porvider(IQueryable<T> q)
        {
            Q = q;
        }

        public IQueryable<T> Q { get; }

        public IQueryable CreateQuery(Expression expression)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            throw new System.NotImplementedException();
        }

        public object Execute(Expression expression)
        {
            throw new System.NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return (TResult)Q.Provider.Execute(expression);
        }
    }
}