using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL;
using CurricolumDAL.GenericCRUDContainer;

namespace CurriculumBIZ.AuthenticationBIZ
{
    public class RuoloCRUD : GenericCrud<GestioneCVEntities,Ruolo>
    {
        public static Ruolo FindById(int id)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Ruolo.Include("User").FirstOrDefault(x => x.id == id);
            }
        }
    }
}
