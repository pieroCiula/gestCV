using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurricolumDAL.GenericCRUDContainer;
using CurricolumDAL;

namespace CurriculumBIZ.AuthenticationBIZ
{
    public class UserCRUD : GenericCrud<GestioneCVEntities,User>
    {

        public static bool Edit(User user)
        {
            using (var ctx = new GestioneCVEntities())
            {
                ctx.User.Attach(user);
                ctx.Entry(user).State = System.Data.EntityState.Modified;
                bool HasEdited = Utility.Utility.HasSaved(ctx.SaveChanges());
                return HasEdited;
            }
        }

        public static User FindById(int id)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.User.Include("Ruolo").FirstOrDefault(x => x.id == id);
            }
        }


        public static List<User> SearchUser(string username, string email, int ruolo)
        {
            using (var ctx = new GestioneCVEntities())
            { 
                IQueryable<User> allUser = ctx.User.Include("Ruolo");
                if(!String.IsNullOrWhiteSpace(username))
                    allUser = allUser.Where(x => x.username.Contains(username));
                if (!String.IsNullOrWhiteSpace(email))
                    allUser = allUser.Where(x => x.email.Contains(email));
                if (ruolo != 0)
                    allUser = allUser.Where(x => x.fk_ruolo == ruolo);
                return allUser.ToList();
            }
        }
        //metodo usato NELL'INSERIMENTO USER per controllare se il nuovo utente che si iscrive al servizio ha un indirizzo mail univoco!
        public static bool EmailAlreadyExist(string email)
        {
            using (var ctx = new GestioneCVEntities())
            {
                var result = ctx.User.FirstOrDefault(x => x.email.Equals(email));
                if (result == null)
                    return false;
                else
                    return true;
            }
        }
        //metodo usato NELL'INSERIMENTO USER per controllare se il nuovo utente che si iscrive al servizio ha username univoco!

        public static bool NameAlreadyExist(string username)
        {
            using (var ctx = new GestioneCVEntities())
            {
                var result = ctx.User.FirstOrDefault(x => x.username.Equals(username));
                if (result == null)
                    return false;
                else
                    return true;
            }
        }
        //metodo usato NELLA MODIFICA USER per controllare se il nuovo utente che si iscrive al servizio ha un indirizzo mail univoco!

        public static bool EmailAlreadyExist(string email, int id)
        {
            using (var ctx = new GestioneCVEntities())
            {
                var result = ctx.User.FirstOrDefault(x => x.email.Equals(email) & x.id != id);
                if (result == null)
                {
                    //se il nome non è presente nell'elenco, allora un nuovo utente può registrarsi con quel nome
                    return false;
                }
                else
                    return true;
            }
        }

        public static bool NameAlreadyExist(string username,int id)
        {
            using (var ctx = new GestioneCVEntities())
            {
                var result = ctx.User.FirstOrDefault(x => x.username.Equals(username) & x.id != id);
                if (result == null)
                {
                    //se il nome non è presente nell'elenco, allora un nuovo utente può registrarsi con quel nome
                    return false;
                }
                else
                    return true;
            }
        }

        public static User FindUserByUsername(string username)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.User.FirstOrDefault(x => x.username == username);
            }
        }

        public static bool Delete(int id)
        {
            using (var ctx = new GestioneCVEntities())
            {
                User userToDelete = ctx.User.FirstOrDefault(x => x.id == id);
                if(userToDelete == null)
                    return false;
                ctx.User.Remove(userToDelete);
                return Utility.Utility.HasSaved(ctx.SaveChanges());

            }

            
        }

        public static bool LogOnExistingUsername(string username)
        {
            using (var ctx = new GestioneCVEntities())
            {
                User user = ctx.User.FirstOrDefault(x => x.username.Equals(username));
                if (user == null)
                    return false;
                else return true;
            }
        }

        public static User LogOnAccess(string username, string password)
        {
            using (var ctx = new GestioneCVEntities())
            {
                return ctx.User.FirstOrDefault(x => x.username.Equals(username) & x.password == password);
            }
        }

        public static String CreateRandomPassword()
        { 
            ////Stringa Password
            //StringBuilder NewPassword = new StringBuilder();
            ////Creo un numero casuale di lunghezza password
            //Random CasualNumber = new Random();
            //int NumberOfChar = CasualNumber.Next(8,16);
            ////inserisco i parametri permessi, che comporranno la password casuale
            //string _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            ////separo ogni singolo carattere... splittandolo con una virgola
            //char[] sep = {','};
            //string[] listOfSplittedChar = _allowedChars.Split(sep);
            ////creo una stringa d'appoggio, che mi servirà nel ciclo
            //string temp = "";
            //for (int i = 0; i < NumberOfChar; i++)
            //{
            //    string carattere = listOfSplittedChar[CasualNumber.Next(0,NumberOfChar)];
            //    //NewPassword.Append(listOfSplittedChar[]);
                
            //}
            String RandomWord = Guid.NewGuid().ToString().Replace("-","").Substring(0,12);
            return RandomWord;
        }

        //Confronta il parametro con la password utente e determina se a quell'user appartierne quella password
        public static bool CheckUserPassword(string Password, string Username)
        {
            using (var ctx = new GestioneCVEntities())
            {
                User user = ctx.User.FirstOrDefault(u => u.username.Equals(Username));
                if (user ==null) 
                    return false;
                if (user.password.Equals(Password))
                    return true;
                else
                    return false;
            }
        }

        //Modifica Password
        public static bool UpdatePassword(string Psw, string Username)
        {
            using (var ctx = new GestioneCVEntities())
            {
                User user = ctx.User.FirstOrDefault(x => x.username == Username);
                user.password = Psw;
                return Utility.Utility.HasSaved(ctx.SaveChanges());

            }
        }
    }
}
