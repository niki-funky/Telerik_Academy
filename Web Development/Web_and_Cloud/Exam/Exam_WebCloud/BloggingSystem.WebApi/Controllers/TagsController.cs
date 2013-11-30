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
using System.Web.Http.ValueProviders;
using BloggingSystem.Models;
using BloggingSystem.DataLayer;
using BloggingSystem.WebApi.Attributes;
using BloggingSystem.WebApi.Models;

namespace BloggingSystem.WebApi.Controllers
{
    public class TagsController : BaseApiController
    {
        // GET api/tags
        public IQueryable<TagModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new BloggingSystemContext();
            var responseMsg = this.PerformOperationAndHandleExceptionsWithSessionKey(
                sessionKey, context, () =>
                {
                    var tagsEntities = context.Tags;
                    var models =
                        (from t in tagsEntities
                         select new TagModel()
                         {
                             Id = t.Id,
                             Name = t.Content,
                             Posts = (context.Posts.Where(
                                     p => p.Tags.Any(x => x.Content == t.Content)).Count())

                         });
                    return models.OrderByDescending(t => t.Id);
                });

            return responseMsg;
        }

        [ActionName("posts")]
        // GET api/tags/{tagId}/posts (where the tag is "more")
        public IQueryable<PostModel> GetPosts(int tagId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new BloggingSystemContext();
            var responseMsg = this.PerformOperationAndHandleExceptionsWithSessionKey(
                sessionKey, context, () =>
                {
                    var tag = context.Tags.FirstOrDefault(t => t.Id == tagId);
                    if (tag == null)
                    {
                        throw new ArgumentException("Tag Id is not valid");
                    }

                    var postEntities = context.Posts;
                    var models =
                        (from p in postEntities
                         where p.Tags.Any(x => x.Id == tagId)
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
    }
}