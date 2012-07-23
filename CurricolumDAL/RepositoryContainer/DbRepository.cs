using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.EntityRepositoryInterface;
using CurricolumDAL.GenericCRUDContainer;

namespace CurricolumDAL.RepositoryContainer
{
    public class DbRepository : GenericCrud<GestioneCVEntities,Db> , IDbRepository
    {

        public Db FindById(int id)
        { 
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Db.Include("Cv").Include("Esperienza").FirstOrDefault(d => d.id == id);
            }
        }

        public bool AlreadyExistingElement(Db db)
        {
            using (var ctx = new GestioneCVEntities())
            {
                if (ctx.Db.Contains(db))
                    return true;
                else
                    return false;
            }
        }
    }
}
