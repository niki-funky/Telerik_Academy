namespace OfferWorld.WebApi.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using OfferWorld.Data;
    using OfferWorld.Models;
    using OfferWorld.WebApi.Headears;
    using OfferWorld.WebApi.Models;

    public class CommentsController : ApiController
    {
        // /api/comments?userId=1
        [HttpGet]
        public IQueryable<CommentModel> GetByUser(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new OfferWorldContext();

            var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
            if (user == null)
            {
                throw new InvalidOperationException("Invalid username or password");
            }

            var commentEntities = context.Comments.Include("User").Include("Item")
                .Where(c => c.User.UserId == user.UserId);
            var models =
                (from commentEntity in commentEntities
                 select new CommentModel()
                 {
                     Id = commentEntity.CommentId,
                     Text = commentEntity.Content,
                     Username = commentEntity.User.Username
                 });
            return models;

        }

        // /api/comments?itemId=1
        [HttpGet]
        public IQueryable<CommentModel> GetByItemId(int itemId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new OfferWorldContext();

            var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
            if (user == null)
            {
                throw new InvalidOperationException("Invalid username or password");
            }

            var commentEntities = context.Comments.Include("User").Include("Item")
                .Where(c => c.Item.ItemId == itemId);
            var models =
                (from commentEntity in commentEntities
                 select new CommentModel()
                 {
                     Id = commentEntity.CommentId,
                     Text = commentEntity.Content,
                     Username = commentEntity.User.Username
                 });
            return models;
        }

        // /api/comments/add
        [ActionName("add")]
        [HttpPost]
        public HttpResponseMessage PostComment([FromBody]CommentPostModel comment,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            try
            {
                using (var context = new OfferWorldContext())
                {
                    var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username or password");
                    }

                    var item = context.Items.SingleOrDefault(b => b.ItemId == comment.ItemId);
                    if (item == null)
                    {
                        throw new InvalidOperationException("This item does not exist.");
                    }

                    var commentToAdd = new Comment();
                    commentToAdd.PostDate = DateTime.Now;
                    commentToAdd.Content = comment.Content;
                    commentToAdd.User = user;
                    commentToAdd.Item = item;
                    context.Comments.Add(commentToAdd);
                    context.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                return errResponse;
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteComment(int id,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            try
            {
                using (var context = new OfferWorldContext())
                {
                    var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                    if (user == null)
                    {
                        throw new UnauthorizedAccessException("Invalid username or password");
                    }

                    var commentEntity = context.Comments.Include("User").SingleOrDefault(u => u.CommentId == id);
                    if (commentEntity == null)
                    {
                        throw new InvalidOperationException("User does not exist.");
                    }

                    if (commentEntity.User.UserId != user.UserId)
                    {
                        throw new InvalidOperationException("You do not have permissions to delete other users' comments.");
                    }

                    context.Comments.Remove(commentEntity);
                    context.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                return errResponse;
            }
        }
    }
}