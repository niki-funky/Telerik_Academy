using System;
using System.Net.Http;
using System.Transactions;
using Forum.WebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using Forum.WebAPI.Controllers;

namespace Forum.Tests
{
    [TestClass]
    public class ThreadsControllerIntegrationTests
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;
        private static readonly UserModel testUser = new UserModel()
        {
            Username = "Valid_User",
            Nickname = "Valid Nickname",
            AuthCode = new string('f', 40)
        };

        [TestInitialize]
        public void TestInit()
        {

            var type = typeof(UsersController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                //new Route(
                //    "ThreadsApi",
                //    "api/threads/{threadId}/posts",
                //    new
                //    {
                //        controller = "threads",
                //        action ="posts"
                //    }),
                new Route(
                    "PostsApi",
                    "api/posts/{postId}/{action}",
                    new
                       {
                           id = RouteParameter.Optional,
                           controller = "posts"
                       }
                    ),
                new Route(
                    "ThreadsApi",
                    "api/threads/{threadId}/{action}",
                    new
                       {
                           id = RouteParameter.Optional,
                            controller = "threads"
                       }
                    ),
                new Route(
                     "UsersApi",
                     "api/users/{action}",
                     new
                        {
                            controller = "users"
                        }),
                        
                new Route(
                    "DefaultApi",
                    "api/{controller}/{id}",
                    new { id = RouteParameter.Optional }),
            };
            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void Register_WhenUserModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
                 {
                     Username = "VALIDUSER",
                     Nickname = "VALIDNICK",
                     AuthCode = new string('b', 40)
                 };
            //var httpServer = new InMemoryHttpServer("http://localhost/");
            var model = this.RegisterTestUser(httpServer, testUser);
            Assert.AreEqual(testUser.Nickname, model.Nickname);
            Assert.IsNotNull(model.SessionKey);
        }

        [TestMethod]
        public void GetAll_WhenDataInDatabase_ShouldReturnData()
        {
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Get("api/threads", headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);                        
        }

        [TestMethod]
        //[ActionName("create")]
        public void PostThread_ShouldSaveToDatabase()
        {
            var testThread = new ThreadModel()
            {
                Title = "Test",
                Content = "Test",
                CreatedBy = "Tester",
                DateCreated = DateTime.Now
            };

            var model = this.PostTestThread(httpServer, testThread);
            Assert.AreEqual(testThread.Title, model.Title);
            Assert.IsTrue(model.Id > 0);
        }

        private ThreadModel PostTestThread(InMemoryHttpServer httpServer, ThreadModel testThread)
        {
            LoggedUserModel loggedUser = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = loggedUser.SessionKey;

            var response = httpServer.Post("api/threads/create", testThread, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var threadModel = JsonConvert.DeserializeObject<ThreadModel>(contentString);
            return threadModel;
        }

        private LoggedUserModel RegisterTestUser(InMemoryHttpServer httpServer, UserModel testUser)
        {
            var response = httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);
            return userModel;
        }
    }
}
