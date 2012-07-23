using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.GenericCRUDContainer;
using CurricolumDAL.EntityRepositoryInterface;

namespace CurricolumDAL.RepositoryContainer
{
    class LinguaggioRepository : GenericCrud<GestioneCVEntities, Linguaggio> , ILinguaggioRepository
    {
        public Linguaggio FindById(int id)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Linguaggio.Include("Cv").Include("Esperienza").FirstOrDefault(x => x.id == id);
            }
        }
    }
}
