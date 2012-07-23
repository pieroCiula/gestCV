using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.EntityRepositoryInterface;

namespace CurricolumDAL.RepositoryContainer
{
    class App_ServerRepository : GenericCRUDContainer.GenericCrud<GestioneCVEntities,App_Server>, IApp_ServerRepository
    {
        public App_Server FindById(int id)
        {
            using(var ctx = new GestioneCVEntities())
            {
                return ctx.App_Server.Include("Cv").Include("Esperienza").FirstOrDefault(a => a.id == id);
            }
        }

        public bool AlreadyExistingElement(App_Server a)
        {
            using (var ctx = new GestioneCVEntities())
            {
                if (ctx.App_Server.Contains(a))
                    return true;
                else
                    return false;
            }
        }
    }
}
