using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.GenericCRUDContainer;
using CurricolumDAL.EntityRepositoryInterface;

namespace CurricolumDAL.RepositoryContainer
{
    public class ValutazioneRepository : GenericCrud<GestioneCVEntities,Valutazione>, IValutazioneRepository
    {
        public Valutazione FindById(int id)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Valutazione.FirstOrDefault(x => x.id == id);
            }
        }

        public bool AlreadyExistingElement(Valutazione v)
        {
            using (var ctx = new GestioneCVEntities())
            {
                if (ctx.Valutazione.Contains(v))
                    return true;
                else
                    return false;
            }
        }
    }
}
