using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using BloggingSystem.Models;
using BloggingSystem.DataLayer;
using BloggingSystem.WebApi.Attributes;
using BloggingSystem.WebApi.Models;

namespace BloggingSystem.WebApi.Controllers
{
    public class UsersController : BaseApiController
    {
        //private BloggingSystemContext db = new BloggingSystemContext();

        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const string ValidUsernameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";
        private const string ValidDisplaynameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_. -";

        private const string SessionKeyChars =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
        private static readonly Random rand = new Random();

        private const int SessionKeyLength = 50;

        private const int Sha1Length = 40;

        public UsersController()
        {
        }

        //http://localhost:2836/

        //POST api/users/register
        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystemContext();
                using (context)
                {
                    this.ValidateUsername(model.Username);
                    this.ValidateDisplayname(model.Displayname);
                    this.ValidateAuthCode(model.AuthCode);
                    var usernameToLower = model.Username.ToLower();
                    var displaynameToLower = model.Displayname.ToLower();
                    var user = context.Users.FirstOrDefault(usr => 
                        usr.Username == usernameToLower ||
                        usr.Displayname.ToLower() == displaynameToLower);

                    if (user != null)
                    {
                        throw new InvalidOperationException("User exists");
                    }

                    user = new User()
                    {
                        Username = usernameToLower,
                        Displayname = model.Displayname,
                        AuthCode = model.AuthCode
                    };

                    context.Users.Add(user);
                    context.SaveChanges();

                    user.SessionKey = this.GenerateSessionKey(user.Id);
                    context.SaveChanges();

                    var loggedModel = new LoggedUserModel()
                    {
                        Displayname = user.Displayname,
                        SessionKey = user.SessionKey
                    };

                    var response =
                        this.Request.CreateResponse(HttpStatusCode.Created,
                            loggedModel);
                    return response;
                }
            });

            return responseMsg;
        }

        //POST api/users/login
        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystemContext();
                using (context)
                {
                    this.ValidateUsername(model.Username);
                    this.ValidateAuthCode(model.AuthCode);
                    var usernameToLower = model.Username.ToLower();
                    var user = context.Users.FirstOrDefault(
                        usr => usr.Username == usernameToLower
                        && usr.AuthCode == model.AuthCode);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username or password");
                    }
                    if (user.SessionKey == null)
                    {
                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        context.SaveChanges();
                    }

                    var loggedModel = new LoggedUserModel()
                    {
                        Displayname = user.Displayname,
                        SessionKey = user.SessionKey
                    };

                    var response =
                        this.Request.CreateResponse(HttpStatusCode.Created,
                                        loggedModel);
                    return response;
                }
            });

            return responseMsg;
        }

        //PUT api/users/logout
        [ActionName("logout")]
        public HttpResponseMessage PutLogoutUser(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystemContext();
                using (context)
                {
                    var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                    if (user != null)
                    {
                        user.SessionKey = null;
                        context.SaveChanges();
                    }
                }
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
            return responseMsg;
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder skeyBuilder = new StringBuilder(SessionKeyLength);
            skeyBuilder.Append(userId);
            while (skeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                skeyBuilder.Append(SessionKeyChars[index]);
            }
            return skeyBuilder.ToString();
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1Length)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted");
            }
        }

        private void ValidateDisplayname(string nickname)
        {
            if (nickname == null)
            {
                throw new ArgumentNullException("nickname cannot be null");
            }
            else if (nickname.Any(ch => !ValidDisplaynameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only Latin letters, digits .,_");
            }
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }
            else if (username.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be at least {0} characters long",
                    MinUsernameLength));
            }
            else if (username.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be less than {0} characters long",
                    MaxUsernameLength));
            }
            else if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only Latin letters, digits .,_");
            }

        }

        private string HashCode(string password)
        {
            System.Text.ASCIIEncoding encoder = new System.Text.ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(password);
            SHA1CryptoServiceProvider cryptoTransformSHA1 =
                new SHA1CryptoServiceProvider();
            string hash = BitConverter.ToString(
                cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");

            return hash;
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}