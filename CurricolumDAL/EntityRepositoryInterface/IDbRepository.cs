using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurricolumDAL.EntityRepositoryInterface
{
    public interface IDbRepository : GenericCRUDContainer.IGenericCrud<Db>
    {
        Db FindById(int id);
    }
}
