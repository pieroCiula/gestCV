using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurricolumDAL.EntityRepositoryInterface
{
    public interface IApp_ServerRepository : GenericCRUDContainer.IGenericCrud<App_Server>
    {
        App_Server FindById(int id);
    }
}
