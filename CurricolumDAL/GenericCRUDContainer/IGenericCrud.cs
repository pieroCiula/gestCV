using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace CurricolumDAL.GenericCRUDContainer
{
    public interface IGenericCrud<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity );

        bool AddAndSave(T entity);

        void Edit(T entity);

        bool EditAndSave(T entity);

        void Delete(T entity);

        bool DeleteAndSave(T entity);

        void DeleteAt(int id);

        bool Save();

    }
}
