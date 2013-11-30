using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using OfferWorld.Models;
using OfferWorld.Data;
using OfferWorld.WebApi.Headears;
using OfferWorld.WebApi.Models;
using System.Web.Http.ValueProviders;

namespace OfferWorld.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        #region PrivateFields
        private const int SessionKeyLength = 50;
        private const string SessionKeyChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        private readonly Random rand = new Random();
        #endregion

        #region Register
        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            try
            {
                using (var context = new OfferWorldContext())
                {
                    Validator.ValidateUsername(model.Username);
                    Validator.ValidateAuthCode(model.AuthCode);
                    Validator.ValidateEmail(model.Email);

                    var usernameToLower = model.Username.ToLower();
                    var username = (context.Users.FirstOrDefault(usr => usr.Username == usernameToLower || usr.Email == model.Email));
                    
                    if (username != null)
                    {
                        throw new ArgumentException("Username or Email already exist");
                    }

                    var user = new User()
                    {
                        Username = model.Username,
                        AuthCode = model.AuthCode, 
                        Email = model.Email,
                        Admin = false
                    };

                    context.Users.Add(user);
                    context.SaveChanges();

                    user.SessionKey = this.GenerateSessionKey(user.UserId);

                    context.SaveChanges();

                    var loggedModel = new UserLoggedModel()
                    {
                        Username = user.Username,
                        SessionKey = user.SessionKey
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);
                    return response;
                }
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                return errResponse;
            }
        }
        #endregion

        #region Login
        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            try
            {
                using (var context = new OfferWorldContext())
                {
                    Validator.ValidateUsername(model.Username);
                    Validator.ValidateAuthCode(model.AuthCode);

                    var usernameToLower = model.Username.ToLower();
                    var user = (context.Users.FirstOrDefault(usr => usr.Username == usernameToLower &&
                            usr.AuthCode == model.AuthCode));

                    if (user == null)
                    {
                        throw new ArgumentException("Username does not exist!");
                    }
                    else if (user.SessionKey == null)
                    {
                        user.SessionKey = this.GenerateSessionKey(user.UserId);
                        context.SaveChanges();
                    }

                    var loggedModel = new UserLoggedModel()
                    {
                        Username = user.Username,
                        SessionKey = user.SessionKey
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);
                    return response;
                }
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                return errResponse;
            }
        }
        #endregion

        #region Logout
        [ActionName("logout")]
        public HttpResponseMessage PutLogoutUser(UserLoggedModel model)
        {
            try
            {
                using (var context = new OfferWorldContext())
                {
                    var user = context.Users.FirstOrDefault(usr => usr.SessionKey == model.SessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid operation.");
                    }

                    user.SessionKey = null;

                    context.SaveChanges();

                    return this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        #endregion

        [ActionName("edit")]
        public HttpResponseMessage PostCreateCategory(EditUserModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            try
            {
                using (var context = new OfferWorldContext())
                {

                    var admin = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey && (usr.Admin == true ||
                        usr.Username == model.Username));

                    if (admin == null)
                    {
                        throw new ArgumentNullException("You have no rights to make changes!");
                    }

                    var userToEdit = context.Users.FirstOrDefault(usr => usr.Username == model.Username);


                    if (model.AuthCode != null)
                    {
                        Validator.ValidateAuthCode(model.AuthCode);
                        userToEdit.AuthCode = model.AuthCode;
                    }

                    if (model.Location != null)
                    {
                        Validator.ValidateLocation(model.Location);
                        userToEdit.Location = model.Location;
                    }

                    if (model.PhoneNumber != null)
                    {
                        Validator.ValidatePhoneNumber(model.PhoneNumber);
                        userToEdit.PhoneNumber = model.PhoneNumber;
                    }

                    if (model.Avatar != null)
                    {
                        Validator.ValidateAvatar(model.Avatar);
                        userToEdit.Avatar = model.Avatar;
                    }

                    context.SaveChanges();

                     
                    return this.Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                return errResponse;
            }
        }

        #region AddInfo
        // Parameters in UserAddInModel - 3,4 or 5
        [ActionName("add-info")]
        public HttpResponseMessage PostUserAddInfo(UserAddInfoModel model)
        {
            try
            {
                using(var context = new OfferWorldContext())
                {

                    Validator.ValidateUsername(model.Username);

                    var user = context.Users.FirstOrDefault(usr => usr.Username == model.Username && usr.SessionKey == model.SessionKey);
                    
                    if (user == null)
                    {
                        throw new ArgumentNullException("Username does NOT exist");
                    }


                    if (model.Location != null)
                    {
                        Validator.ValidateLocation(model.Location);
                        user.Location = model.Location;
                    }

                    if(model.PhoneNumber != null)
                    {
                        Validator.ValidatePhoneNumber(model.Location);
                        user.PhoneNumber = model.PhoneNumber;
                    }

                    if (model.Avatar != null)
                    {
                        Validator.ValidateAvatar(model.Avatar);
                        user.Avatar = model.Avatar;
                    }

                    context.SaveChanges();

                    return this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                return errResponse;
            }
        }

        #endregion

        #region PrivateMethods
        private string GenerateSessionKey(int userId)
        {
            int userIdLength = userId.ToString().Length;
            string sessionKey = userId.ToString();
            for (var i = 0; i < SessionKeyLength - userIdLength; i++)
            {
                sessionKey += SessionKeyChars[rand.Next(0, SessionKeyChars.Length)];
            }
            return sessionKey;
        }
        #endregion
    }
}