using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.EntityRepositoryInterface;
using CurricolumDAL.GenericCRUDContainer;

namespace CurricolumDAL.RepositoryContainer
{
    public class FrameworkRepository : GenericCrud<GestioneCVEntities,Framework> , IFrameworkRepository
    {
        public Framework FindById(int id)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Framework.Include("Cv").Include("Esperienza").FirstOrDefault(x => x.id == id);
            }
        }

        public bool AlreadyExistingElement(Framework f)
        {
            using (var ctx = new GestioneCVEntities())
            {
                if (ctx.Framework.Contains(f))
                    return true;
                else
                    return false;
            }
        }
    }
}
