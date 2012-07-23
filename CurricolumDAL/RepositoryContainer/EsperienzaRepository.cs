using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurricolumDAL.RepositoryContainer
{
    class EsperienzaRepository : GenericCRUDContainer.GenericCrud<GestioneCVEntities,Esperienza> , EntityRepositoryInterface.IEsperienzaRepository
    {
        public Esperienza FindById(int id)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Esperienza.Include("Cv_Esperienza")
                    .Include("Esperienza_App_Server")
                    .Include("Ambiente_Ide")
                    .Include("Db")
                    .Include("Framework")
                    .Include("Linguaggio")
                    .Include("Versioning_Configuration")
                    .FirstOrDefault(x => x.id == id);
            }
        }
    }
}
