using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurricolumDAL.EntityRepositoryInterface
{
    public interface ICertificazioneRepository : GenericCRUDContainer.IGenericCrud<Certificazione>
    {
        Certificazione FindById(int id);
    }
}
