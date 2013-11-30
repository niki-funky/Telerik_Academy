using System.Web.Http.ValueProviders;
using DataLayer;
using Forum.Model;
using Forum.WebAPI.Attributes;
using Forum.WebAPI.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Forum.WebAPI.Controllers
{
    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const int MinNicknameLength = 6;
        private const int MaxNicknameLength = 30;
        private const string ValidUsernameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";
        private const string ValidNicknameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_. -";

        private const string SessionKeyChars =
            "1qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
        //private static readonly Random rand = new Random();
        private readonly Random rand = RandomProvider.GetThreadRandom();

        private const int SessionKeyLength = 50;

        private const int Sha1Length = 40;

        public UsersController()
        {
        }

        /*
        {  "username": "DonchoMinkov",
           "nickname": "Doncho Minkov",
           "authCode":   "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e" }
        */

        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new ForumContext();
                    using (context)
                    {
                        this.ValidateUsername(model.Username);
                        this.ValidateNickname(model.Nickname);
                        this.ValidateAuthCode(model.AuthCode);
                        var usernameToLower = model.Username.ToLower();
                        var nicknameToLower = model.Nickname.ToLower();
                        var user = context.Users.FirstOrDefault(usr =>
                            usr.Username == usernameToLower ||
                            usr.Nickname.ToLower() == nicknameToLower);

                        if (user != null)
                        {
                            throw new InvalidOperationException("User exists");
                        }

                        user = new User()
                        {
                            Username = usernameToLower,
                            Nickname = model.Nickname,
                            AuthCode = model.AuthCode
                        };

                        context.Users.Add(user);
                        context.SaveChanges();

                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        context.SaveChanges();

                        var loggedModel = new LoggedUserModel()
                        {
                            Nickname = user.Nickname,
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

        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  var context = new ForumContext();
                  using (context)
                  {
                      this.ValidateUsername(model.Username);
                      this.ValidateAuthCode(model.AuthCode);
                      var usernameToLower = model.Username.ToLower();
                      var user = context.Users.FirstOrDefault(usr =>
                          usr.Username == usernameToLower &&
                          usr.AuthCode == model.AuthCode);

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
                          Nickname = user.Nickname,
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

        [ActionName("logout")]
        public HttpResponseMessage PutLogoutUser(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  var context = new ForumContext();
                  using (context)
                  {
                      this.ValidateSessionKey(sessionKey);

                      var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

                      if (user == null)
                      {
                          throw new InvalidOperationException("Invalid user");
                      }

                      user.SessionKey = null;
                      context.SaveChanges();

                      var response =
                          this.Request.CreateResponse(HttpStatusCode.OK);
                      return response;
                  }
              });

            return responseMsg;
        }

        // data parsers
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

        private void ValidateNickname(string nickname)
        {
            if (nickname == null)
            {
                throw new ArgumentNullException("Nickname cannot be null");
            }
            else if (nickname.Length < MinNicknameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Nickname must be at least {0} characters long",
                    MinNicknameLength));
            }
            else if (nickname.Length > MaxNicknameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Nickname must be less than {0} characters long",
                    MaxNicknameLength));
            }
            else if (nickname.Any(ch => !ValidNicknameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Nickname must contain only Latin letters, digits .,_");
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

        private void ValidateSessionKey(string sessionKey)
        {
            string id = sessionKey.AsEnumerable().Where(char.IsDigit).ToString();
            int index = sessionKey.IndexOf(id);
            string keyWithoutId = 
                (index < 0) ? sessionKey : sessionKey.Remove(index, id.Length);
            if (sessionKey.Length != SessionKeyLength || 
                keyWithoutId.Any(ch => !SessionKeyChars.Contains(ch)))
            {
                throw new ArgumentException("Invalid Password");
            }
        }
    }
}
