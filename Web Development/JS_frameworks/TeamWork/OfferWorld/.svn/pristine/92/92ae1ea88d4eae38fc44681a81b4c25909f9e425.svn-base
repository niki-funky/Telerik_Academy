using System.IO;
using System.Web;
using OfferWorld.Data;
using OfferWorld.WebApi.Headears;
using OfferWorld.WebApi.Helpers;
using OfferWorld.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OfferWorld.Models;
using System.Web.Http.ValueProviders;

namespace OfferWorld.WebApi.Controllers
{
    public class ItemsController : ApiController
    {
        [ActionName("all")]
        public IQueryable<GetItemsModel> GetAllItems(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new OfferWorldContext();


            //Validator.ValidateUsername(model.Username);

            var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

            if (user == null)
            {
                throw new ArgumentNullException("You are not logged in!");
            }

            var itemsEntity = context.Items;



            var allItems = (from item in itemsEntity
                            select new GetItemsModel()
                            {
                                Id = item.ItemId,
                                Title = item.Title,
                                Price = item.Price,
                                Description = item.Description,
                                AdInfo = item.AdInfo,
                                User = item.User.Username,
                                Category = item.Category.Name,
                                Comments = item.Comments, //TODO create CommentModel
                                Pictures = (from picture in item.Pictures
                                           select new PictureModel()
                                           {
                                               Link = picture.Link
                                           })

                                //Offers = item.Offers                                 //TODO add offers

                            }).ToList();

            return allItems.AsQueryable();
        }

        public IQueryable<GetItemsModel> GetItemById(int id,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            return this.GetAllItems(sessionKey).Where(i => i.Id == id);
        }

        public IQueryable<GetItemsModel> GetItemsByCategory(string category,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            return this.GetAllItems(sessionKey).Where(i => i.Category == category);
        }

        [ActionName("offer")]
        public void PutOfferForItem(int id,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var item = this.GetAllItems(sessionKey).Where(i => i.Id == id).FirstOrDefault();

            var context = new OfferWorldContext();

            var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
            item.Offers.Add(new Offer()
            {
                User = user,
                Item = new Item()
                {
                    ItemId = item.Id
                }
            });

        }

        [ActionName("create")]
        public HttpResponseMessage PostCreateItem(ItemCreateModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            try
            {
                using (var context = new OfferWorldContext())
                {

                    //Validator.ValidateUsername(model.Username);

                    var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new ArgumentNullException("You are not logged in!");
                    }

                    var category = context.Categories.FirstOrDefault(cat => cat.Name == model.Category);

                    var newItem = new Item()
                    {
                        Title = model.Title,
                        Price = model.Price,
                        Description = model.Description,
                        AdInfo = model.AdInfo,
                        Category = category,
                        User = user,

                    };                    
                    
                    context.Items.Add(newItem);

                    var picture = new Picture()
                        {
                            Link = "http://www.design.svetu.com/wp-content/gallery/clients/no_image.gif",
                            Item = newItem
                        };

                    if (model.Pictures.Length == 0)
                    {
                        context.Pictures.Add(picture);
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

        [HttpPost]
        [ActionName("sendFile")]
        public string SendFile(string reciever,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new OfferWorldContext();
            var sender = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

            string url = this.UploadFile(HttpContext.Current.Request.Files[0], sender);

            return url;
        }

        public string UploadFile(HttpPostedFile postedFile, User dbUser)
        {
            var fileName = DateTime.Now.Ticks + dbUser.Username + postedFile.FileName;
            var path = HttpContext.Current.Server.MapPath("~/App_Data/") + fileName;
            postedFile.SaveAs(path);

            var url = DropBoxUploader.UploadImageToDropBox(path, fileName);
            File.Delete(path);

            return url;
        }

    }
}
