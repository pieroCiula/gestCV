using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurricolumDAL.EntityRepositoryInterface
{
    public interface ILinguaggioRepository : GenericCRUDContainer.IGenericCrud<Linguaggio>
    {
        Linguaggio FindById(int id);
    }
}
