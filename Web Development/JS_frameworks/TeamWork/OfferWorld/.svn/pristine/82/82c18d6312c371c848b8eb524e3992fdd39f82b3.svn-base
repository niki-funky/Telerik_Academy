using OfferWorld.Data;
using OfferWorld.Models;
using OfferWorld.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OfferWorld.WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        

        [ActionName("create")]
        public HttpResponseMessage PostCreateCategory(CategoryModelCreate model)
        {
            try
            {
                using (var context = new OfferWorldContext())
                {
                     Validator.ValidateCategoryTitle(model.Title);

                     var user = context.Users.FirstOrDefault(usr => usr.SessionKey == model.SessionKey && usr.Admin == true);
                     if (user == null)
                     {
                         throw new ArgumentNullException("You have no rights to make changes!");
                     }

                     var category = context.Categories.FirstOrDefault(cat => cat.Name == model.Title);

                     if (category != null)
                     {
                         throw new ArgumentException("Category already exists!");
                     }

                     context.Categories.Add(new Category()
                         {
                             Name = model.Title
                         });
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

        [ActionName("delete")]
        public HttpResponseMessage PostDeleteCategory(CategoryModelCreate model)
        {
            try
            {
                using (var context = new OfferWorldContext())
                {
                    Validator.ValidateCategoryTitle(model.Title);

                    var user = context.Users.FirstOrDefault(usr => usr.SessionKey == model.SessionKey && usr.Admin == true);

                    if (user == null)
                    {
                        throw new ArgumentNullException("You have no rights to make changes!");
                    }

                    Category category = context.Categories.FirstOrDefault(cat => cat.Name == model.Title);
                    context.Categories.Remove(category);

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
        

    }
}
