using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BloggingSystem.DataLayer;

namespace BloggingSystem.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        protected T PerformOperationAndHandleExceptions<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errResponse);
            }
        }

        protected T PerformOperationAndHandleExceptionsWithSessionKey<T>(
            string sessionKey, BloggingSystemContext context, Func<T> operation)
        {
            try
            {
                TryLogin<T>(sessionKey, context);

                return operation();
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errResponse);
            }
        }

        private static void TryLogin<T>(string sessionKey, BloggingSystemContext context)
        {
            var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
            if (user == null)
            {
                throw new InvalidOperationException("Invalid username or password");
            }
        }
    }
}
