using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CurriculumWEB.Models.AccountSessionModel
{
    public class AccountModel
    {
        public int id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage="Il campo può avere minimo 3 caratteri")]
        [MaxLength(50,ErrorMessage="Il campo può avere al massimo 50 caratteri")]
        public string username { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Il campo può avere minimo 5 caratteri")]
        [MaxLength(50, ErrorMessage = "Il campo può avere al massimo 50 caratteri")]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name="Ruolo")]
        public int fk_ruolo { get; set; }

        public List<SelectListItem> listaRuoli { get; set; }
        //public virtual Ruolo Ruolo { get; set; }

    }

    public class LogOnModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Il campo può avere minimo 3 caratteri")]
        [MaxLength(50, ErrorMessage = "Il campo può avere al massimo 50 caratteri")]
        public string username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Il campo deve avere minimo 5 caratteri")]
        [MaxLength(50, ErrorMessage = "Il campo può avere al massimo 50 caratteri")]
        public string password { get; set; }

    }


    public class RegistrationModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Il campo può avere minimo 3 caratteri")]
        [MaxLength(50, ErrorMessage = "Il campo può avere al massimo 50 caratteri")]
        public string username { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [MinLength(8, ErrorMessage = "Il campo deve avere minimo 8 caratteri")]
        [MaxLength(50, ErrorMessage = "Il campo può avere al massimo 50 caratteri")]
        public string email { get; set; }
    }

    public class Resetpassword 
    {
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Il campo deve avere minimo 5 caratteri")]
        [MaxLength(50, ErrorMessage = "Il campo può avere al massimo 50 caratteri")]
        public string OldPassword { get; set; }

        [Required]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Il campo deve avere minimo 5 caratteri")]
        [MaxLength(50, ErrorMessage = "Il campo può avere al massimo 50 caratteri")]
        public string NewPassword { get; set; }

        [Required, Compare("NewPassword",ErrorMessage="La password di conferma non è uguale a quella immessa")]
        [Display(Name = "Compare Password")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Il campo deve avere minimo 5 caratteri")]
        [MaxLength(50, ErrorMessage = "Il campo può avere al massimo 50 caratteri")]
        public string ComparePassword { get; set; }
    }


}