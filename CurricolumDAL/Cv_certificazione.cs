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
    public partial class Cv_certificazione
    {
        public int fk_Certificazione { get; set; }
        public int fk_Cv { get; set; }
        public Nullable<System.DateTime> data_conseguimento { get; set; }
    
        public virtual Certificazione Certificazione { get; set; }
        public virtual Cv Cv { get; set; }
    }
    
}
