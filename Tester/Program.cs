using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurriculumBIZ;
using CurricolumDAL;
namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Dipendente dip = new Dipendente();
            Console.WriteLine("nome: ");
            dip.nome = Console.ReadLine();
            Console.WriteLine("cognome: ");
            dip.cognome=Console.ReadLine();
            DateTime dt = new DateTime(2001,12,25);
            dip.data_nascita = dt;
            Console.WriteLine("istruzione: ");
            dip.istruzione = Console.ReadLine();
            Console.WriteLine("nome_istituto ");
            dip.nome_istituto = Console.ReadLine();
            

            bool x = DipendenteCRUD.AddDipendente(dip);
            Console.WriteLine("successo: "+x);


            Console.ReadLine();
        }
    }
}
