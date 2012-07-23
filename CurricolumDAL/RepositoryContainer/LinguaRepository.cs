using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.EntityRepositoryInterface;
using CurricolumDAL.GenericCRUDContainer;

namespace CurricolumDAL.RepositoryContainer
{
    public class LinguaRepository : GenericCRUDContainer.GenericCrud<GestioneCVEntities,Lingua> 
        , ILinguaRepository
    {
        
        //ritorna la lista di tutte le LIngua di un Cv
        public List<Lingua>GetAllLinguaOfCv(int id_Cv)
        {
            using (var ctx = new GestioneCVEntities())
            {
                List<Lingua> listLingua = ctx.Lingua.Include("Cv").Include("Tipo_Lingua").Where(x => x.Cv.id == id_Cv).ToList();
                return listLingua;
            }
        }


        public Lingua GetSingle(int id_Cv, int id_Tipo_Lingua)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Lingua.Include("Cv").Include("Tipo_Lingua").FirstOrDefault(x => x.fk_Cv == id_Cv & x.fk_Tipo_lingua == id_Tipo_Lingua);
            }
        }
    }
}
