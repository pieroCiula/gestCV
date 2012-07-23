using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurriculumBIZ;
using CurricolumDAL;
using CurricolumDAL.RepositoryContainer;
using CurricolumDAL.EntityRepositoryInterface;
using CurricolumDAL.GenericCRUDContainer;
using CurriculumBIZ.Utility;
namespace Tester
{
    class Program
    {
        public static Tipo_LinguaRepository tipo_lin = new Tipo_LinguaRepository();
        static void Main(string[] args)
        {
            //Dipendente dip = new Dipendente();
            //Console.WriteLine("nome: ");
            //dip.nome = Console.ReadLine();
            //Console.WriteLine("cognome: ");
            //dip.cognome=Console.ReadLine();
            //DateTime dt = new DateTime(2001,12,25);
            //dip.data_nascita = dt;
            //Console.WriteLine("istruzione: ");
            //dip.istruzione = Console.ReadLine();
            //Console.WriteLine("nome_istituto ");
            //dip.nome_istituto = Console.ReadLine();
            
            
            //bool x = DipendenteCRUD.AddDipendente(dip);
            //Console.WriteLine("successo: "+x);

            //Console.WriteLine(aggiungi());
            //Console.WriteLine(edit());

            List<int> A = new List<int> { 2, 4, 6, 8, 10, 12, 14, 16 };
            List<int> B = new List<int> { 3, 6, 9, 12, 15, 18 };

            List<int> x = A.Except(B).ToList(); 
            Console.WriteLine("A: ");
            foreach(int n in A)
            {
                Console.Write(n);
            }

            Console.WriteLine("B: ");
            foreach (int n in B)
            {
                Console.Write(n);
            }

            Console.WriteLine(" A.Except(B)");
            foreach (int n in x)
            {
                Console.Write(n);
            }

            x = B.Except(A).ToList(); 

            Console.WriteLine(" B.Except(A)");
            foreach (int n in x)
            {
                Console.Write(n);
            }

            x = A.Union(B).ToList();

            Console.WriteLine(" A.Union(B)");
            foreach (int n in x)
            {
                Console.Write(n);
            }

            x = B.Union(A).ToList();

            Console.WriteLine(" B.Union(A)");
            foreach (int n in x)
            {
                Console.Write(n);
            }

            Console.ReadLine();


        }

        public static bool aggiungi()
        {
            var tl = new Tipo_lingua { nome = "Inglese" };
            return tipo_lin.AddAndSave(tl);
        }

        public static bool edit()
        {
            Tipo_lingua tl = tipo_lin.FindById(1);
            tl.nome = "Francese";
            return tipo_lin.EditAndSave(tl);
        }
    }

}
