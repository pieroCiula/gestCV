using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurricolumDAL.EntityRepositoryInterface
{
    public interface ICv : GenericCRUDContainer.IGenericCrud<Cv>
    {
        Cv FindById(int id);
    }

}
