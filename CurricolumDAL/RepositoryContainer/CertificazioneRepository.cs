using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.EntityRepositoryInterface;
using CurricolumDAL.GenericCRUDContainer;

namespace CurricolumDAL.RepositoryContainer
{
    class CertificazioneRepository : GenericCrud<GestioneCVEntities, Certificazione> , ICertificazioneRepository
    {
        public Certificazione FindById(int id)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Certificazione.Include("Cv_Certificazione.Certificazione").FirstOrDefault(x => x.id == id);
            }
        }

        public bool AlreadyExistingElement(Certificazione c)
        {
            using (var ctx = new GestioneCVEntities())
            {
                if (ctx.Certificazione.Contains(c))
                    return true;
                else
                    return false;
            }
        }
    }
}
