using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurricolumDAL.EntityRepositoryInterface
{
    public interface IAmbiente_IdeRepository: GenericCRUDContainer.IGenericCrud<Ambiente_Ide>
    {
        Ambiente_Ide FindById(int id);
    }
}
