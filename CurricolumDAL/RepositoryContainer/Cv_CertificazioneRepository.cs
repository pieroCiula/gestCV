using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.GenericCRUDContainer;
using CurricolumDAL.EntityRepositoryInterface;

namespace CurricolumDAL.RepositoryContainer
{
    public class Cv_CertificazioneRepository : GenericCrud<GestioneCVEntities, Cv_certificazione> , ICv_CertificazioneRepository
    {
        public List<Cv_certificazione> GetCertificazioniWithThisCvId(int id_Cv)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Cv_certificazione.Where(x => x.Cv.id == id_Cv).ToList();
            }
        }

        public List<Cv_certificazione> GetCvWithThisCertificazioneId(int id_certificazione)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Cv_certificazione.Where(x => x.Certificazione.id ==  id_certificazione).ToList();
            }
        }

        public Cv_certificazione GetCertificazione(int id_Cv, int id_certificazione)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Cv_certificazione.FirstOrDefault(x => x.Certificazione.id == id_certificazione & x.Cv.id == id_Cv);
            }
        }
    }
}
