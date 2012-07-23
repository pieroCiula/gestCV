using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurricolumDAL.EntityRepositoryInterface
{
    public interface IEsperienzaRepository : GenericCRUDContainer.IGenericCrud<Esperienza>
    {
        Esperienza FindById(int id);
    }
}
