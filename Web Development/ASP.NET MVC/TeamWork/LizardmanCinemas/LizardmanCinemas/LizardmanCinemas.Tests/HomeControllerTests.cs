using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LizardmanCinemas.Controllers;
using LizardmanCinemas.Data;
using LizardmanCinemas.Models;
using LizardmanCinemas.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LizardmanCinemas.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexSahouldReturnThreeMovies()
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "pesho"
            };

            var list = new List<Movie>();
            list.Add(new Movie()
                {
                    Id = 1,
                    Title = "pesho",
                    Poster = "c.jpg",
                    Year = 2000,
                    Trailer = "pesho.com",
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                         CommentText="asssaaa",
                          CreatedOn = DateTime.Now,
                           Id = 1,
                            User = user
                        }
                    }
                });

            var movieRepoMock = new Mock<IRepository<Movie>>();
            movieRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());
            //movieRepoMock.Setup(x=>x.All().Take(3).Select(MovieHomeVM.FromMovie).ToList()).Returns(list);

            var uowMock = new Mock<IUowData>();
            //uowMock.Setup(x=>x.SaveChanges()).Returns(()=>{return 3});
            uowMock.Setup(x => x.Movies).Returns(movieRepoMock.Object);

            var controller = new HomeController(uowMock.Object);

            var viewresult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewresult, "ViewResult is Null");
            var resModel = viewresult.Model;
            var model = viewresult.Model as IEnumerable<MovieHomeVM>;
            Assert.IsNotNull(model, "The model is Null");
            Assert.AreEqual(1, model.Count());
        }
    }
}
