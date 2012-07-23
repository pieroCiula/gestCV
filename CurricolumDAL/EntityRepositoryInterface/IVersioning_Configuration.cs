using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.GenericCRUDContainer;

namespace CurricolumDAL.EntityRepositoryInterface
{
    public interface IVersioning_Configuration : IGenericCrud<Versioning_Configuration>
    {
        Versioning_Configuration FindById(int id);
    }
}
