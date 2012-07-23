using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.GenericCRUDContainer;
using CurricolumDAL.RepositoryContainer;

namespace CurricolumDAL.GenericCRUDContainer
{
    interface IDipendenteRepository : IGenericCrud<Dipendente>
    {
        Dipendente FindById(int id);

        List<Dipendente> Search(string nome, string cognome, DateTime data_nascita, string istruzione, string nome_istituto);


    }
}
