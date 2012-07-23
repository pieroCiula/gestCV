using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.EntityRepositoryInterface;
using CurricolumDAL.GenericCRUDContainer;

namespace CurricolumDAL.RepositoryContainer
{
    public class Cv_EsperienzaRepository : GenericCrud<GestioneCVEntities,Esperienza> , ICv_Esperienza
    {

        public Cv_Esperienza  GetSingle(int id_Cv, int id_esperienza)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Cv_Esperienza.Include("Cv").Include("Esperienza").FirstOrDefault(x => x.fk_Cv == id_Cv & x.fk_esperienza == id_esperienza);
            }
        }

        public List<Cv_Esperienza>  GetAllWithThisEsperienza(int id_esperienza)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Cv_Esperienza.Include("Cv").Include("Esperienza").Where(x => x.fk_esperienza == id_esperienza).ToList();
            }
        }

        public List<Cv_Esperienza>  GetAllWithThisCv(int id_Cv)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Cv_Esperienza.Include("Cv").Include("Esperienza").Where(x => x.fk_Cv == id_Cv).ToList();
            }
        }
    }
}
