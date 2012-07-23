using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurricolumDAL.EntityRepositoryInterface
{
    public interface ICv_Esperienza : GenericCRUDContainer.IGenericCrud<Esperienza>
    {
        Cv_Esperienza GetSingle(int id_Cv, int id_esperienza);

        List<Cv_Esperienza> GetAllWithThisEsperienza(int id_esperienza);

        List<Cv_Esperienza> GetAllWithThisCv(int id_Cv);
    }
}
