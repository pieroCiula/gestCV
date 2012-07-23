using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CurriculumWEB.Models.AccountSessionModel
{
    public class RuoloModel
    {

        public int id { get; set; }
        [Required]
        [Range(4,10,ErrorMessage="Il campo può contenere dai 4 ai 10 caratteri")]
        public string tipo_ruolo { get; set; }

        //public virtual ICollection<User> User { get; set; }
    }
}