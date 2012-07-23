using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurricolumDAL.EntityRepositoryInterface
{
    public interface IValutazioneRepository : GenericCRUDContainer.IGenericCrud<Valutazione>
    {
        Valutazione FindById(int id);
    }
}
