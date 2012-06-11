using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurriculumBIZ.Utility
{
    class Utility
    {
        //metodo che prende un ctx.Savechange e restituisce vero se una query ha interessato una o più righe del Db
        public static bool HasSaved(int x)
        {
            if (x > 0)
            {
                return true;
            }
            else return false;
        }

    }
}
