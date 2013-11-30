using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using BloggingSystem.Models;
using BloggingSystem.DataLayer;
using BloggingSystem.WebApi.Attributes;
using BloggingSystem.WebApi.Models;

namespace BloggingSystem.WebApi.Controllers
{
    public class PostsController : BaseApiController
    {
        //GET api/posts
        public IQueryable<PostModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new BloggingSystemContext();
            var responseMsg = this.PerformOperationAndHandleExceptionsWithSessionKey(
                sessionKey, context, () =>
            {
                var postEntities = context.Posts;
                var models =
                    (from p in postEntities
                     select new PostModel()
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Text = p.Text,
                        PostDate = p.PostDate,
                        PostedBy = p.User.Displayname,
                        Tags = (from t in p.Tags
                                select t.Content),
                        Comments = (from c in p.Comments
                                    select new CommentModel()
                                    {
                                        Text = c.Text,
                                        CommentedBy = p.User.Displayname,
                                        PostDate = c.PostDate
                                    })
                    });
                return models.OrderByDescending(p => p.PostDate);
            });

            return responseMsg;
        }

        //Get api/posts?page=P&count=C
        public IQueryable<PostModel> GetPage(int page, int count,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var posts = this.GetAll(sessionKey)
                .Skip(page * count)
                .Take(count)
                .OrderByDescending(x => x.PostDate);
            return posts;
        }

        [HttpGet]
        //GET api/posts?tags=much,webapi
        public IQueryable<PostModel> GetPostsByTags(string tags,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var arrOfWords = tags.Split(',');
            List<PostModel> result = new List<PostModel>();
            var posts = this.GetAll(sessionKey);
            foreach (var post in posts)
            {
                var tag = post.Tags;
                if (arrOfWords.All(x => tag.Contains(x)))
                {
                    result.Add(post);
                }
            }

            return result.AsQueryable<PostModel>().OrderByDescending(x => x.PostDate);
        }

        [HttpGet]
        //GET api/posts?keyword=webapi
        public IQueryable<PostModel> GetPostsByKeyword(string keyword,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var posts = this.GetAll(sessionKey)
                .Where(t => t.Tags.Any(x => x.Contains(keyword)))
                .OrderByDescending(x => x.PostDate);
            return posts;
        }

        //POST api/posts/
        public HttpResponseMessage PostCreate(PostModel post,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new BloggingSystemContext();
            var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
            var responseMsg = this.PerformOperationAndHandleExceptionsWithSessionKey(
                sessionKey, context, () =>
            {
                var newPost = new Post();
                newPost.Title = post.Title;
                newPost.Text = post.Text;
                newPost.PostDate = DateTime.Now;
                newPost.User = user;
                newPost.Tags = new List<Tag>();

                var pattern = new Regex(
                    @"( [^\W_\d]              # starting with a letter
                                              # followed by a run of either...
                        ( [^\W_\d] |          #   more letters or
                          [-'\d](?=[^\W_\d])  #   ', -, or digit followed by a letter
                        )*
                        [^\W_\d]              # and finishing with a letter
                      )",
                    RegexOptions.IgnorePatternWhitespace);

                foreach (Match m in pattern.Matches(newPost.Title))
                {
                    var tagContent = m.Groups[1].Value.ToLower();
                    if (context.Tags.FirstOrDefault(t => t.Content == tagContent) == null)
                    {
                        newPost.Tags.Add(new Tag()
                        {
                            Content = tagContent,
                        });
                    }
                }

                context.Posts.Add(newPost);
                context.SaveChanges();

                var createdPost = new CreatedPost()
                {
                    Id = newPost.Id,
                    Title = newPost.Title
                };

                var response = this.Request.CreateResponse(HttpStatusCode.Created, createdPost);
                return response;
            });

            return responseMsg;
        }

        [ActionName("comment")]
        //PUT api/posts/{postId}/comment
        public HttpResponseMessage PutComment(CommentModel comment, int postId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new BloggingSystemContext();
            var responseMsg = this.PerformOperationAndHandleExceptionsWithSessionKey(
                sessionKey, context, () =>
            {
                var post = context.Posts.FirstOrDefault(p => p.Id == postId);
                if (post != null)
                {
                    post.Comments.Add(new Comment()
                    {
                        Text = comment.Text,
                        PostDate = DateTime.Now,
                    });
                }
                context.SaveChanges();

                var response = this.Request.CreateResponse(HttpStatusCode.Created);
                return response;
            });

            return responseMsg;
        }
    }
}