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
        bool EmailExists(string email);
        void Register(string email, string password);
        string GetLoginEmail(string email);
        string GetLoginPassword(string password);
        void SetIsLoggedIn(bool isLogged);
        void SetUserEmail(string email);
        string GetUserEmail();
        void SetUserEntry(string email);
        int GetUserEntry();
        string GetUserPhoneNumber(string email);
        bool UserIsMod(string email);
        List<string> GetPosts(string city);
        List<string> GetUserPosts(int entry);
        List<string> GetPostsToAccept();
        string GetPostImage(string post);
        void PostCreate(int accountEntry, string title, string description, string city, string image);
        int GetPostEntry(string post);
        string GetPostTitle(int entry);
        string GetPostDescription(int entry);
        string GetPostImage(int entry);
    }

    public class EntityService : IEntityService
    {
        public bool EmailExists(string email)
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
                var account = new AccountsModel { email = email, password = password, isMod = false };

                db.Accounts.Add(account);
                db.SaveChanges();
            }

            using (var db = new SqlLiteContext())
            {
                var account = new AccountModel { isLogged = true };

                db.Account.Add(account);
                db.SaveChangesAsync();
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

        public void SetIsLoggedIn(bool isLogged)
        {
            using (var db = new SqlLiteContext())
            {
                var account = db.Account.FirstOrDefault();

                if (isLogged == false)
                {
                    account.isLogged = false;

                    db.Account.Update(account);
                    db.SaveChangesAsync();
                }
                else
                {
                    account.isLogged = true;

                    db.Account.Update(account);
                    db.SaveChangesAsync();
                }
            }
        }

        public void SetUserEmail(string email)
        {
            using (var db = new SqlLiteContext())
            {
                var account = db.Account.FirstOrDefault();

                account.email = email;

                db.Account.Update(account);
                db.SaveChangesAsync();
            }
        }

        public string GetUserEmail()
        {
            using (var db = new SqlLiteContext())
            {
                return db.Account.Select(x => x.email).FirstOrDefault();
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

                account.user_entry = entry;

                db.Account.Update(account);
                db.SaveChangesAsync();
            }
        }

        public int GetUserEntry()
        {
            using (var db = new SqlLiteContext())
            {
                return db.Account.Select(x => x.user_entry).FirstOrDefault();
            }
        }

        public string GetUserPhoneNumber(string email)
        {
            using (var db = new SqlContext())
            {
                return db.Accounts.Where(x => x.email == email).Select(x => x.phoneNumber).FirstOrDefault();
            }
        }

        public bool UserIsMod(string email)
        {
            using (var db = new SqlContext())
            {
                return db.Accounts.Where(x => x.email == email).Select(x => x.isMod).FirstOrDefault();
            }
        }

        public List<string> GetPosts(string city)
        {
            using (var db = new SqlContext())
            {
                return db.Posts.Where(x => x.city == city).Select(x => x.title).ToList();
            }
        }

        public List<string> GetUserPosts(int entry)
        {
            using (var db = new SqlContext())
            {
                return db.Posts.Where(x => x.account_entry == entry).Select(x => x.title).ToList();
            }
        }

        public string GetPostImage(string post)
        {
            using (var db = new SqlContext())
            {
                return db.Posts.Where(x => x.title == post).Select(x => x.image).FirstOrDefault();
            }
        }

        public List<string> GetPostsToAccept()
        {
            using (var db = new SqlContext())
            {
                return db.Posts.Where(x => x.accepted == false).Select(x => x.title).ToList();
            }
        }

        public void PostCreate(int accountEntry, string title, string description, string city, string image)
        {
            using (var db = new SqlContext())
            {
                PostsModel postsModel = new PostsModel()
                {
                    account_entry = accountEntry,
                    title = title,
                    description = description,
                    city = city,
                    image = image,
                    active = true,
                    accepted = false
                };

                db.Posts.Add(postsModel);
                db.SaveChanges();
            }
        }

        public int GetPostEntry(string post)
        {
            using (var db = new SqlContext())
            {
                return db.Posts.Where(x => x.image == post).Select(x => x.entry).FirstOrDefault();
            }
        }

        public string GetPostTitle(int entry)
        {
            using (var db = new SqlContext())
            {
                return db.Posts.Where(x => x.entry == entry).Select(x => x.title).FirstOrDefault();
            }
        }

        public string GetPostDescription(int entry)
        {
            using (var db = new SqlContext())
            {
                return db.Posts.Where(x => x.entry == entry).Select(x => x.description).FirstOrDefault();
            }
        }

        public string GetPostImage(int entry)
        {
            using (var db = new SqlContext())
            {
                return db.Posts.Where(x => x.entry == entry).Select(x => x.image).FirstOrDefault();
            }
        }
    }
}
