//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace CurricolumDAL
{
    public partial class Dipendente
    {
        public Dipendente()
        {
            this.Cv = new HashSet<Cv>();
        }
    
        public int id { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public System.DateTime data_nascita { get; set; }
        public string istruzione { get; set; }
        public string nome_istituto { get; set; }
    
        public virtual ICollection<Cv> Cv { get; set; }
    }
    
}
