using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurricolumDAL.EntityRepositoryInterface
{
    public interface ICv_CertificazioneRepository : GenericCRUDContainer.IGenericCrud<Cv_certificazione>
    {
        List<Cv_certificazione> GetCertificazioniWithThisCvId(int id_Cv);

        List<Cv_certificazione> GetCvWithThisCertificazioneId(int id_certificazione);

        Cv_certificazione GetCertificazione(int id_Cv, int id_certificazione);
    }
}
