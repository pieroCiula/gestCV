using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurricolumDAL.EntityRepositoryInterface
{
    public interface ILinguaRepository : GenericCRUDContainer.IGenericCrud<Lingua>
    {

        //Ritorna tutte le lingue di un determinato curricolum
        List<Lingua> GetAllLinguaOfCv(int id_Cv);

        Lingua GetSingle(int id_Cv, int id_Tipo_Lingua);
        
    }
}
