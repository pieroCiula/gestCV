using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.GenericCRUDContainer;

namespace CurricolumDAL.RepositoryContainer
{
    public class DipendenteRepository : GenericCrud<GestioneCVEntities,Dipendente> , IDipendenteRepository
    {

        public Dipendente FindById(int id)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.Dipendente.Include("Cv").FirstOrDefault(d => d.id == id);
            }
        }

        public List<Dipendente> Search(string nome, string cognome, DateTime data_nascita, string istruzione, string nome_istituto)
        {
            using (var ctx = new GestioneCVEntities())
            {
                IEnumerable<Dipendente> AllDipendenti = ctx.Dipendente;
                if (!String.IsNullOrWhiteSpace(nome))
                    AllDipendenti = AllDipendenti.Where(d => d.nome == nome);
                if (!String.IsNullOrWhiteSpace(cognome))
                    AllDipendenti = AllDipendenti.Where(d => d.cognome == cognome);
                if (data_nascita !=null)
                    AllDipendenti = AllDipendenti.Where(d => d.nome == nome);
                if (!String.IsNullOrWhiteSpace(istruzione))
                    AllDipendenti = AllDipendenti.Where(d => d.istruzione == istruzione);
                if (!String.IsNullOrWhiteSpace(nome_istituto))
                    AllDipendenti = AllDipendenti.Where(d => d.nome_istituto == nome_istituto);
                return AllDipendenti.ToList();
            }
        }
    }
}
