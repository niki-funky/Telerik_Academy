using System;
using System.Collections.Generic;
using System.Net;
using System.Transactions;
using System.Web.Http;
using BloggingSystem.WebApi.Controllers;
using BloggingSystem.WebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BloggingSystem.Tests
{
    [TestClass]
    public class PostsControllerIntegrationTests
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;
        private static readonly UserModel testUser = new UserModel()
        {
            Username = "Valid_User",
            Displayname = "Valid Displayname",
            AuthCode = new string('f', 40)
        };

        private static readonly PostModel testPost = new PostModel()
        {
            PostDate = DateTime.Now,
            Title = "NEW POST",
            Text = "this is just a test post" 
        };

        private static readonly TagModel testTag = new TagModel()
        {
            Name = "post",
        };

        [TestInitialize]
        public void TestInit()
        {
            var type = typeof(UsersController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                new Route(
                    "UsersApi",
                    "api/users/{action}",
                    new
                       {
                            controller = "users"
                       }
                    ),
                new Route(
                    "PostsApi",
                    "api/posts/{postId}/{action}",
                    new
                       {
                            postId = RouteParameter.Optional,
                            controller = "posts"
                       }
                    ),
                new Route(
                     "TagsApi",
                     "api/tags/{tagId}/{action}",
                     new
                        {
                            tagId = RouteParameter.Optional,
                            controller = "tags"
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
        public void GetAllPosts_ShouldReturnData()
        {
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Get("api/posts", headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void GetPostsByTags_ShouldReturnData()
        {
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;

            var response = httpServer.Get("api/posts?page=1&count=2", headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void GetAllTags_ShouldReturnData()
        {
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Get("api/tags", headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void GetPostsByTag_ShouldReturnData()
        {
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Get("api/tags/1/posts ", headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void Logout()
        {
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Put("api/users/logout", headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        private PostModel PostCreatePost(InMemoryHttpServer httpServer, PostModel testPost)
        {
            LoggedUserModel loggedUser = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = loggedUser.SessionKey;

            var response = httpServer.Post("api/posts/create", testPost, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<PostModel>(contentString);
            return postModel;
        }

        private PostModel PostCreateTag(InMemoryHttpServer httpServer, TagModel testTag)
        {
            LoggedUserModel loggedUser = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = loggedUser.SessionKey;

            var response = httpServer.Post("api/posts/create", testTag, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<PostModel>(contentString);
            return postModel;
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
