using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL;
using CurriculumBIZ.Utility;
namespace CurriculumBIZ
{
    public class DipendenteCRUD
    {
        //ADD DIPENDENTE- OVERLOAD 1
        public static bool AddDipendente(string nome, string cognome, DateTime data_nascita, string istruzione, string nome_istituto)
        {
            using(var ctx = new GestioneCVEntities())
            {
                Dipendente dip = new Dipendente { nome = nome, cognome = cognome, data_nascita = data_nascita, istruzione = istruzione, nome_istituto = nome_istituto };
                ctx.Dipendente.Add(dip);
                return Utility.Utility.HasSaved(ctx.SaveChanges());
            }
        }

        //ADD DIPENDENTE - OVERLOAD 2
        public static bool AddDipendente(Dipendente dip)
        {
            return AddDipendente(dip.nome,dip.cognome, dip.data_nascita, dip.istruzione, dip.nome_istituto);
        }


    }
}
