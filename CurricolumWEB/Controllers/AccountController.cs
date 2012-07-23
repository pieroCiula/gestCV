using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurriculumWEB.Models.AccountSessionModel;
using CurriculumBIZ.AuthenticationBIZ;
using CurricolumDAL;
using System.Web.Security;

namespace CurriculumWEB.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
            return View();
            }//altrimenti se non autenticato ritorna a logOn
            return RedirectToAction("LogOn");
        }


        public ActionResult LogOn()
        {
            if (!Request.IsAuthenticated)
            {
                return View();
            }
            else return View("AlredyAuthenticated");
        }


        [HttpPost]
        public ActionResult LogOn(LogOnModel model)
        {
            if (!Request.IsAuthenticated)
            {
                if (!UserCRUD.LogOnExistingUsername(model.username))
                { 
                    ModelState.AddModelError("NotExistingAccount", "Questo Account non esiste! Inserisci nuovamente l'username");
                }
                if (ModelState.IsValid)
                {
                    User user = UserCRUD.LogOnAccess(model.username, model.password);
                    if (user == null)
                    {
                        ModelState.AddModelError("NoCorrectPassword", "Password non corretta!");
                        return View();
                    }
                    else { 
                        //cookie
                        //permette di memorizzare delle info sul cookie
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
                        (1, //numero di versione del ticket
                        user.username,// nome dell'username a cui appartiene il cookie
                        DateTime.Now, //data e ora locali in cui il COOKIE è STATO EMESSO
                        DateTime.Now.Add(FormsAuthentication.Timeout)//è la data di scadenza del ticket, quando termina l'user viene deloggato 
                            // il Timeout è di 2800 sec, per default è così, ma possiamo modificarlo andando su WEB.CONFIG nel tag <Authentication> e poi nel tag<TimeOut>
                        , false //persistenza... da mettere sempre a false
                        , user.Ruolo.tipo_ruolo //nel cookie scriviamo anche il ruolo che ha quell'utente nell'applicazione web
                        );

                        //crittografo il cookie per renderlo sicuro altrimenti chiunque può prenderlo e verificare ciò che vi ho scritto dentro
                        var encticket = FormsAuthentication.Encrypt(ticket);

                        //Aggiunge All'insieme dei Cookie il nome del Cookie ed il contenuto del ticket crittografato nel cookie
                        HttpContext.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encticket));
                        return RedirectToAction("Index", "Home");
                        //return Redirect(FormsAuthentication.GetRedirectUrl(user.username, false));
                    }
                }
                else 
                {
                    ModelState.AddModelError("ErrorInModel", "spiacente hai compilato l'user con valori non adatti");
                    return View();
                }
            }
            else 
            {
                //return RedirectToAction("ControlPannel");
            }
            return View();
        }


        public ActionResult SetPsw() 
        {
            return PartialView("SetPswView");
        }

        [HttpPost]
        public ActionResult SetPsw(Resetpassword RstPsw)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("SetPassView");
            }
            else
            { 
                String Username = User.Identity.Name;
                bool OldPswIsCorrect = UserCRUD.CheckUserPassword(RstPsw.OldPassword, Username);
                if (!OldPswIsCorrect || RstPsw.NewPassword.Equals(RstPsw.ComparePassword))
                {
                    ModelState.AddModelError("SetPswModelInvalid", "Spiacente la vecchia password non corrisponde alla tua password attuale");
                    return PartialView("SetPassView");
                }
                bool HasNewPassword = UserCRUD.UpdatePassword(RstPsw.NewPassword, Username);
                if (HasNewPassword)
                {
                    TempData["SettingSuccess"] = "<p style='color=green'>Password Modificata Correttamente!</p>";
                    return View();
                }
                else
                {
                    TempData["SettingSuccess"] = "Non è stato possibile modificare la password, modifica i campi in modo corretto e riprova!";
                    return View();
                }
            }
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(LogOnModel logOnModel)
        {

            if (ModelState.IsValid)
            {

            }
            TempData["c"] = UserCRUD.CreateRandomPassword();
            return View();
        }

        

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }



        public ActionResult NameAlreadyExist(string username)
        {
            bool AlreadyExist = UserCRUD.NameAlreadyExist(username);
            return Json(AlreadyExist, JsonRequestBehavior.AllowGet);
        }



        public ActionResult EmailAlreadyExist(string email)
        {
            bool AlreadyExist = UserCRUD.EmailAlreadyExist(email);
            return Json(AlreadyExist, JsonRequestBehavior.AllowGet);
        }

    }
}
