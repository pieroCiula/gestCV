using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CurricolumDAL.EntityRepositoryInterface
{
    public interface ITipo_LinguaRepository : GenericCRUDContainer.IGenericCrud<Tipo_lingua>
    {
        Tipo_lingua FindById(int id);

    }
}
