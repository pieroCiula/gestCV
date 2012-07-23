using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.GenericCRUDContainer;
using CurricolumDAL.EntityRepositoryInterface;
namespace CurricolumDAL.RepositoryContainer
{
    public class CvRepository : GenericCrud<GestioneCVEntities,Cv> , ICv
    {
        public Cv FindById(int id)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Cv.Include("Cv_certificazione")
                    .Include("Dipendente")
                    .Include("Cv_Esperienza")
                    .Include("Lingua")
                    .Include("Ambiente_Ide")
                    .Include("App_Server")
                    .Include("Db")
                    .Include("Framework")
                    .Include("Linguaggio")
                    .Include("Versioning_Configuartion")
                    .FirstOrDefault(x => x.id == id);
            }
        }
    }
}
