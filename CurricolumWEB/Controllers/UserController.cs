using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurriculumBIZ.AuthenticationBIZ;
using CurriculumWEB.Models.AccountSessionModel;
using CurricolumDAL;
using System.Web.UI;
using System.Web.Caching;

namespace CurriculumWEB.Controllers.AccountSession
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        

        public static UserCRUD user_repo = new UserCRUD();
        

        public static UserModel UserToModel(User user)
        {
            UserModel model = new UserModel
            {
                id = user.id,
                username = user.username,
                password = user.password,
                email = user.email,
                fk_ruolo = user.fk_ruolo
            };
             return model;
        }

        public static User ModelToUser(UserModel model)
        {
            User user = new User
            {
                id = model.id,
                username = model.username,
                password = model.password,
                email = model.email,
                fk_ruolo = model.fk_ruolo
            };
            return user;
        }

        public ActionResult QuickUsernameSearch(string term)
        {
            List<User> listUser = user_repo.GetAll().Where(x => x.username.Contains(term)).ToList();
            var selectUserList = listUser.Select(x => new { value = x.username }).Take(10);
            return Json(selectUserList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult QuickEmailSearch(string term)
        {
            IEnumerable<User> listUser = user_repo.GetAll().Where(x => x.email.Contains(term)).Take(10);
            var selectUserList = listUser.Select(x => new { value = x.email });
            return Json(selectUserList,JsonRequestBehavior.AllowGet);
        }


       

        
        public ActionResult SearchUser(string username, string email, int dropdown_ruolo)
        {
            Session.Add("SearchUsernameParameters",username) ;
            Session.Add("SearchEmailParameters",email);
            Session.Add("SearchRuoloParameters",dropdown_ruolo);
            if (username == null)
                username = string.Empty;
            if (email == null)
                email = string.Empty;
            List<User> listaRicerca= UserCRUD.SearchUser(username,email,dropdown_ruolo);
            
            return PartialView("ShowAllUser", listaRicerca );
        }


        public static List<User> SearchOptimization(List<User>SessionList,string username, string email, int dropdown_ruolo)
        {
            List<User> ListResult = new List<User>();
            if (SessionList == null)
            {
                return UserCRUD.SearchUser(username, email, dropdown_ruolo).OrderBy(x => x.username).ThenBy(x => x.email).ThenBy(x => x.fk_ruolo).ToList();
            
            }
            ListResult = SearchFromSession(SessionList, username, email, dropdown_ruolo);
            List<User> ListDbResult = UserCRUD.SearchUser(username, email, dropdown_ruolo);
            var Result =UnionSessionAndList(ListResult, ListDbResult).OrderBy(x => x.username).ThenBy(x => x.email).ThenBy(x => x.fk_ruolo);
            return Result.ToList();
        }
        //La sessione è stata ottimizzata per ottimizzare le ricerche, gli autocomplete;
        //Prima di effettuare una ricerca sul DB, viene interrogata la Sessione.
        
        //---Start Session Methods

        public static List<User> SearchFromSession(IEnumerable<User> SessionList, string username, string email, int dropdown_ruolo)
        {
            if(!String.IsNullOrWhiteSpace(username))
                SessionList = SessionList.Where(x =>x.username.Contains( username));
            if (!String.IsNullOrWhiteSpace(email))
                SessionList = SessionList.Where(x => x.email.Contains(email));
            if (dropdown_ruolo != 0)
                SessionList = SessionList.Where(x => x.fk_ruolo == dropdown_ruolo);
            return SessionList.ToList();

        }


        public static List<User> EditElementFromSession(List<User> SessionList, User UserEdited) 
        {
            User EditingUser = SessionFindById(SessionList,UserEdited.id);
            if (EditingUser != null)
            {
                SessionList.Remove(EditingUser);
                
            }
            SessionList.Add(UserEdited);
            return SessionList;
        }

        public static void DeleteElementFromSession(List<User> SessionList, User UserItem)
        {
            bool IsInside = SessionContainsUserById(SessionList,UserItem);
            if (IsInside)
            {
                SessionList.Remove(UserItem);
            }
        }

        public static bool AddUserToSession(User user, List<User> SessioneUser)
        {
            bool AlredyExistingUser = SessionContainsUserById(SessioneUser, user);
            if (!AlredyExistingUser)
            {
                SessioneUser.Add(user);
                return true;
            }
            else
                return false;
        }
        
        //Ritorna null se non trova l'elemento , altrimenti torna l'elemento stesso contenuto nell'insieme Sessione
        public static bool SessionContainsUserById(List<User> SessioneUser, User UserItem)
        {
            User user = SessionFindById(SessioneUser, UserItem.id);
            if (user == null)
            {
                
                return true;
            }
            else 
                return false;
        }

        public static User SessionFindById(List<User> SessionList, int IdUser)
        {
            return SessionList.FirstOrDefault(x => x.id == IdUser);
        }

        //Adding new list to Session
        public static List<User> UnionSessionAndList(List<User> listaUser,List<User> SessionList)
        {
            
            foreach (var item in listaUser)
            {
                if (SessionList.FirstOrDefault(x => x.id == item.id) == null)
                { 
                    //se nullo l'emento non è presente nella lista sessione e deve essere aggiunto
                    SessionList.Add(item);
                }
            }
            return SessionList;
        }


        //----Fine Session Methods




        public ActionResult Index()
        {
            
           return View();
        }

        //[Authorize(Roles = "admin")]
        public ActionResult ShowPswUser(int id)
        {
            User user = UserCRUD.FindById(id);
            return PartialView("ShowPswUser",user);
        }
        
        //[Authorize(Roles = "admin")]
        public ActionResult ShowAllUser()
        {
            Session["SearchUsernameParameters"] = ""; ;
            Session["SearchEmailParameters"] = "";
            Session["SearchRuoloParameters"] = 0;
            var listAllUser = GetAllUser();
            return PartialView("ShowAllUser", listAllUser);
        }

        //[OutputCache(  Duration = 3600, VaryByParam="ListAllUser", Location= OutputCacheLocation.ServerAndClient)]
        public static List<User> GetAllUser(){
            return user_repo.GetAll().ToList();
        }

        public static List<SelectListItem> CreateDropDownRuolo()
        {
            List<Ruolo> AllRuoloList = Controllers.RuoloController.GetAllRuolo();
            var SelectListRuolo = AllRuoloList.Select(r => new SelectListItem { Value = r.id.ToString(), Text = r.tipo_ruolo }).ToList();
            return SelectListRuolo;
        }

        public ActionResult AddUser()
        {
            List<SelectListItem> SelectListRuolo = CreateDropDownRuolo();
            UserModel model = new UserModel {listaRuoli = SelectListRuolo};
            return View(model);        
        }

        

        [HttpPost]
        public ActionResult AddUser(UserModel model)
        {
            
            if (model.fk_ruolo <= 0)
                ModelState.AddModelError("fkRuoloError", "Non hai definito il ruolo dell'utente");
            if(ModelState.IsValid)
            {
            User user = ModelToUser(model);  
            bool HasAdded = user_repo.AddAndSave(user);
                if(HasAdded)
                {
                    User UserAdded = UserCRUD.FindUserByUsername(user.username);
                    TempData["UserSuccess"] = "Modifica Utente Avvenuta con successo!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UserFailed"] = "Spiacente non è stato possibile aggiungere l'user!";
                    return View("AddUser", model);
                }
            }else
            {
                TempData["UserFailed"] = "Spiacente il modello non è valido!";
                model.listaRuoli = CreateDropDownRuolo();

                return View("AddUser", model);
            }
        }
        
        //Ritorna TRue se la stringa USername già è presente nel DB

        public ActionResult CheckIfNameAlreadyExist( string username, int id)
        {
            bool AlredyExist;
            if (id == 0)
            {
                AlredyExist = UserCRUD.NameAlreadyExist(username);
            }
            else
            {
                AlredyExist = UserCRUD.NameAlreadyExist(username, id);
            }
            return Json(AlredyExist,JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckIfEmailAlreadyExist(string email, int id)
        {
            bool AlredyExist;
            if (id == 0)
            {
                AlredyExist = UserCRUD.EmailAlreadyExist(email);
            }
            else
            {
                AlredyExist = UserCRUD.NameAlreadyExist(email, id);
            }
            return Json(AlredyExist, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditUser(int id)
        {
            User user =UserCRUD.FindById(id);
            if(user == null)
            {
                TempData["UserFailed"] = "Spiacente non è possibile apportare modifiche ad un utente non esistente";
                RedirectToAction("Index");
            }
            UserModel model = UserToModel(user);
            List<SelectListItem> SelectListRuolo = CreateDropDownRuolo();
            model.listaRuoli = SelectListRuolo;
            return View(model); 
        }

        [HttpPost]
        public ActionResult EditUser(UserModel model)
        {
            if (model.fk_ruolo <= 0)
                ModelState.AddModelError("fkRuoloError", "Non hai definito il ruolo dell'utente");
            if(ModelState.IsValid)
            {
            User user = ModelToUser(model);
            bool HasEdited = UserCRUD.Edit(user);
                if (HasEdited)
                {
                    
                    TempData["UserSuccess"] = "Modifica Utente Avvenuta con successo!";
                    return RedirectToAction("Index");
                }
                else
                {
                    List<SelectListItem> SelectListRuolo = CreateDropDownRuolo();
                    model.listaRuoli = SelectListRuolo;
                    TempData["UserFailed"] = "Spiacente non è stato possibile modificare l'user!";
                    return RedirectToAction("Index");

                }
            }else
            {
                List<SelectListItem> SelectListRuolo = CreateDropDownRuolo();
                model.listaRuoli = SelectListRuolo;
                TempData["UserFailed"] = "Spiacente il modello non è valido!";
                return View("EditUser", model);
            }
        }

        public ActionResult DeleteUser(int id)
        {
            User user = UserCRUD.FindById(id);
            return PartialView("DeleteUser",user);
        }

        [HttpPost]
        public ActionResult DeleteConfirmUser(int id)
        {
            bool HasDeleted = UserCRUD.Delete(id);
            if (HasDeleted)
            {
                TempData["UserSuccess"] = "Cancellazione Utente Avvenuta con successo!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["UserFailed"] = "Spiacente non è stato possibile eliminare l'user!";
                return RedirectToAction("Index");
            }
        }

        //prende i valori username,email e dropdown da i parametri di ricerca allocati in sessione e restituisce una nuova lista da passare a SHOW ALL
        public ActionResult SearchRememberUpdating()
        {
            string username = (string)Session["SearchUsernameParameters"];
            string email =(string) Session["SearchEmailParameters"];
            int dropdown_ruolo = (int)Session["SearchRuoloParameters"];
            if (username == null)
                username = string.Empty;
            if (email == null)
                email = string.Empty;
            List<User> ListaUserRicerca = UserCRUD.SearchUser(username, email, dropdown_ruolo);
            return PartialView("ShowAllUser", ListaUserRicerca);
        }

    }
}
