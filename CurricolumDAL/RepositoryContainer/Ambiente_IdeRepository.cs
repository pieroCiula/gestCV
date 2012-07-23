using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.GenericCRUDContainer;
using CurricolumDAL.EntityRepositoryInterface;

namespace CurricolumDAL.RepositoryContainer
{
    public class Ambiente_IdeRepository : GenericCrud<GestioneCVEntities, Ambiente_Ide> , IAmbiente_IdeRepository
    {

        public Ambiente_Ide FindById(int id)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Ambiente_Ide.Include("Cv").Include("Esperienza").FirstOrDefault(x => x.id == id);
            }
        }

        public bool AlreadyExistingElement(Ambiente_Ide amb_ide)
        {
            using (var ctx = new GestioneCVEntities())
            {
                if (ctx.Ambiente_Ide.Contains(amb_ide))
                    return true;
                else
                    return false;
            }
        }
    }
}
