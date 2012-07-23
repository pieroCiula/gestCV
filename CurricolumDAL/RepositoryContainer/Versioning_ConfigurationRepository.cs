using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.GenericCRUDContainer;
using CurricolumDAL.EntityRepositoryInterface;

namespace CurricolumDAL.RepositoryContainer
{
    public class Versioning_ConfigurationRepository : GenericCrud<GestioneCVEntities,Versioning_Configuration> , IVersioning_Configuration
    {

        public Versioning_Configuration FindById(int id)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Versioning_Configuration.Include("Cv").Include("Esperienza").FirstOrDefault(d => d.id == id);
            }
        }

        public bool AlreadyExistingElement(Versioning_Configuration v)
        {
            using (var ctx = new GestioneCVEntities())
            {
                if (ctx.Versioning_Configuration.Contains(v))
                    return true;
                else
                    return false;
            }
        }
    }
}
