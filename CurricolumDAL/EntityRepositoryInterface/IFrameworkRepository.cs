﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurricolumDAL.EntityRepositoryInterface
{
    public interface IFrameworkRepository : GenericCRUDContainer.IGenericCrud<Framework>
    {
        Framework FindById(int id);
    }
}
