using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//contiene DbContex... e devo aggiungere questo assembly
using System.Data.Entity;

namespace CurricolumDAL.GenericCRUDContainer
{
    //i metodi della CRUD generica sono rigorosamente virtual in modo che se serva un'implementazione che differisce dalla
    //generica gestione crud, il metodo di interesse può essere sovrascritto

    public abstract class GenericCrud<C, T> : IDisposable,
                    IGenericCrud<T>
        where T : class
        where C : DbContext, new()
    {
        //_entity è una proprietà di tipo che eredita da DbContext
        private C _entities = new C();

        //proprietà di tipo contesto che eredita da DbContext, utile nelle CRUD, si trova
        //all'interno della classe per creare Dipendency Injection... in modo che il contesto non dipenda dalla classe
        protected C Context { get; set; }

        //indica se l'entità in questione è stata cancellata o meno
        private bool disposed = false;

        //questo metodo ritorna tutti gli elementi diun db set
        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        //Tramite il metodo seguente è possibile tornare un IQUERYABLE che rispetti una determinata funzione DELEGATA
        public virtual IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual bool AddAndSave(T entity) 
        {
            Add(entity);
            return Save();
        }

        //Bisogna attaccare l'oggetto al contesto per poi cancellarlo, tuttalpiù si può usare Entry-State di EF
        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Attach(entity);
            _entities.Set<T>().Remove(entity);
        }


        public virtual void Edit(T entity)
        {
            _entities.Set<T>().Attach(entity);
            _entities.Entry(entity).State = System.Data.EntityState.Modified;
        }

        public virtual bool Save()
        {
            int x = _entities.SaveChanges();
            return Utility.Utility.HasSaved(x);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    _entities.Dispose();
            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void DeleteAt(int id)
        {
            throw new NotImplementedException();
        }


        public bool EditAndSave(T entity)
        {
            Edit(entity);
            return Save();
        }

        public bool DeleteAndSave(T entity)
        {
            Delete(entity);
            return Save();
        }


    }
}
