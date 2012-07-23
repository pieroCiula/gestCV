using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.EntityRepositoryInterface;
using CurricolumDAL.GenericCRUDContainer;
namespace CurricolumDAL.RepositoryContainer
{
    public class Tipo_LinguaRepository : GenericCrud<GestioneCVEntities,Tipo_lingua>, ITipo_LinguaRepository
    {

        public Tipo_lingua FindById(int id)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Tipo_lingua.Include("Lingua").FirstOrDefault(x => x.id == id);
            }
        }

        public bool AlreadyExistingElement(Tipo_lingua tl)
        {
            using (var ctx = new GestioneCVEntities())
            {
                if (ctx.Tipo_lingua.Contains(tl))
                    return true;
                else
                    return false;
            }
        }

    }
}
