using SharingFood.Contexts;
using SharingFood.Models;
using System.Linq;

namespace SharingFood.Services
{
    public interface IEntityService
    {
        bool CheckIfEmailExists(string email);
        void Register(string email, string password);
        string GetLoginEmail(string email);
        string GetLoginPassword(string password);
        void SetIsLoggedIn();
    }

    public class EntityService : IEntityService
    {
        public bool CheckIfEmailExists(string email)
        {
            using (var db = new SqlContext())
            {
                var result = db.Accounts.Where(x => x.email == email).Select(x => x.email).FirstOrDefault();

                if (result == null)
                    return false;
                else
                    return true;
            }
        }

        public void Register(string email, string password)
        {
            using (var db = new SqlContext())
            {
                var account = new AccountsModel { email = email, password = password };

                db.Accounts.Add(account);
                db.SaveChanges();
            }
        }

        public string GetLoginEmail(string Email)
        {
            string _email;

            using (var db = new SqlContext())
            {
                var email = db.Accounts.Where(x => x.email == Email).Select(x => x.email).FirstOrDefault();
                _email = email;
            }

            return _email;
        }

        public string GetLoginPassword(string Password)
        {
            string _password;

            using (var db = new SqlContext())
            {
                var password = db.Accounts.Where(x => x.password == Password).Select(x => x.password).FirstOrDefault();
                _password = password;
            }

            return _password;
        }

        public static bool IsLoggedIn()
        {
            using (var db = new SqlLiteContext())
            {
                bool isLoggedIn = db.Account.Select(x => x.isLogged).FirstOrDefault();

                if (isLoggedIn == true)
                    return true;
                else
                    return false;
            }
        }

        public void SetIsLoggedIn()
        {
            using (var db = new SqlLiteContext())
            {
                if (db.Account.Any())
                {
                    var account = db.Account.FirstOrDefault();

                    if (account != null)
                        account.isLogged = true;

                    db.Account.Update(account);
                    db.SaveChangesAsync();
                }
                else
                {
                    var account = new AccountModel { isLogged = true };

                    db.Account.Add(account);
                    db.SaveChangesAsync();
                }
            }
        }
    }
}
