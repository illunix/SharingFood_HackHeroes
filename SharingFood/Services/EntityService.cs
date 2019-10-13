using SharingFood.Contexts;
using SharingFood.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace SharingFood.Services
{
    public interface IEntityService
    {
        bool CheckIfEmailExists(string email);
        void Register(string email, string password);
        string GetLoginEmail(string email);
        string GetLoginPassword(string password);
        void SetIsLoggedIn();
        void SetUserEntry(string email);
        int GetUserEntry();
        List<string> GetPosts();
        ImageSource GetPostImage(string post);
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

                    if (account.isLogged == false)
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

        public void SetUserEntry(string email)
        {
            int entry;

            using (var db = new SqlContext())
            {
                entry = db.Accounts.Where(x => x.email == email).Select(x => x.entry).FirstOrDefault();
            }

            using (var db = new SqlLiteContext())
            {
                var account = db.Account.FirstOrDefault();

                if (account != null)
                    account.user_entry = entry;

                db.Account.Update(account);
                db.SaveChangesAsync();
            }
        }

        public int GetUserEntry()
        {
            int entry;

            using (var db = new SqlLiteContext())
            {
                entry = db.Account.Select(x => x.user_entry).FirstOrDefault();
            }

            return entry;
        }

        public List<string> GetPosts()
        {
            var posts = new List<string>();

            using (var db = new SqlContext())
            {
                posts = db.Posts.Select(x => x.title).ToList();
            }

            return posts;
        }

        public ImageSource GetPostImage(string post)
        {
            using (var db = new SqlContext())
            {
                var base64Image = db.Posts.Where(x => x.title == post).Select(x => x.image).FirstOrDefault();

                byte[] base64Stream = Convert.FromBase64String(base64Image);

                return ImageSource.FromStream(() => new MemoryStream(base64Stream));
            }
        }
    }
}
