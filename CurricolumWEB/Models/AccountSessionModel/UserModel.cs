using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CurriculumWEB.Models.AccountSessionModel
{
    public class UserModel
    {
        public int id { get; set; }
        
        [Required]
        public string username { get; set; }
        
        [Required]
        [DataType( DataType.Password)]
        public string password { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        
        public int fk_ruolo { get; set; }

        public List<SelectListItem> listaRuoli { get; set; }
        //public virtual Ruolo Ruolo { get; set; }    
    }
}