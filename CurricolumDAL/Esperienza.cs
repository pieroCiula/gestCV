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
    public partial class Esperienza
    {
        public Esperienza()
        {
            this.Cv_Esperienza = new HashSet<Cv_Esperienza>();
            this.Esperienza_App_Server = new HashSet<Esperienza_App_Server>();
            this.Ambiente_Ide = new HashSet<Ambiente_Ide>();
            this.Db = new HashSet<Db>();
            this.Framework = new HashSet<Framework>();
            this.Linguaggio = new HashSet<Linguaggio>();
            this.Versioning_Configuration = new HashSet<Versioning_Configuration>();
        }
    
        public int id { get; set; }
        public string nome_datore { get; set; }
        public string indirizzo_datore { get; set; }
        public string nome_progetto { get; set; }
        public string mansione { get; set; }
        public string tipo_linguaggio { get; set; }
    
        public virtual ICollection<Cv_Esperienza> Cv_Esperienza { get; set; }
        public virtual ICollection<Esperienza_App_Server> Esperienza_App_Server { get; set; }
        public virtual ICollection<Ambiente_Ide> Ambiente_Ide { get; set; }
        public virtual ICollection<Db> Db { get; set; }
        public virtual ICollection<Framework> Framework { get; set; }
        public virtual ICollection<Linguaggio> Linguaggio { get; set; }
        public virtual ICollection<Versioning_Configuration> Versioning_Configuration { get; set; }
    }
    
}