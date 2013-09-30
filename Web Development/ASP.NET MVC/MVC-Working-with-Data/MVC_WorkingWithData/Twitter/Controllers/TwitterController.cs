using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.Controllers
{
    [Authorize]
    [ValidateInput(false)]
    public class TwitterController : BaseController
    {
        IUowData db;

        public TwitterController()
            : base(null)
        {
            db = new UowData();
        }

        public TwitterController(IUowData db)
            : base(db)
        {
        }

        // GET: /Twitter/
        public ActionResult Index()
        {
            var tweets = this.db.Tweets.All().Include(t => t.Tags).ToList().Select(tw => new Tweet()
            {
                Id = tw.Id,
                Content = tw.Content,
                Creator = tw.User.UserName,
                Tags = tw.Tags,
                User = tw.User
            });

            ViewBag.CheckAdminRole = this.CheckAdminRole();

            return View(tweets);
        }

        // GET: /Twitter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.GetById(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // GET: /Twitter/Search/someTag
        [OutputCache(Duration = 900, VaryByParam = "*")]
        public ActionResult Search(string tag)
        {
            if (tag == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tweets = db.Tweets.All().Where(t => t.Tags.Any(tg => tg.Text.Contains(tag))).ToList();
            if (tweets == null)
            {
                return HttpNotFound();
            }

            ViewBag.CheckAdminRole = this.CheckAdminRole();

            return PartialView("Tweets", tweets);
        }

        // GET: /Twitter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Twitter/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
             [Bind(Include = "Content")]
             Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                var content = tweet.Content;
                tweet.Content = content.ParseURL().ParseHashtag();
                tweet.Creator = HttpContext.User.Identity.Name;
                //Guid user = (Guid)Membership.GetUser(User.Identity.Name).ProviderUserKey;
                tweet.User = db.Users.All().FirstOrDefault(u => u.UserName == User.Identity.Name);
                tweet.Tags = content.GetHashtag().Select(t => new Tag() { Text = t }).ToList();

                db.Tweets.Add(tweet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tweet);
        }

        // GET: /Twitter/Edit/5
        [RoleAuthorize(Roles = "Admin, Error")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.All()
                .Include(t => t.Tags)
                .FirstOrDefault(twit => twit.Id == id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // POST: /Twitter/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [RoleAuthorize(Roles = "Admin, Error")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            //[Bind(Include = "Content,Creator,User")] 
            Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                var currTweet = db.Tweets.GetById(tweet.Id);

                var content = tweet.Content;
                currTweet.Content = content.ParseURL().ParseHashtag();
                currTweet.Creator = tweet.Creator;
                currTweet.User = tweet.User;
                currTweet.Tags = content.GetHashtag().Select(t => new Tag() { Text = t }).ToList();

                this.db.Tweets.Update(currTweet);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tweet);
        }

        // GET: /Twitter/Delete/5
        [RoleAuthorize(Roles = "Admin, Error")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.All()
                .Include(t => t.Tags)
                .FirstOrDefault(twit => twit.Id == id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // POST: /Twitter/Delete/5
        [RoleAuthorize(Roles = "Admin, Error")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tweet tweet = db.Tweets.All()
                .Include(t => t.Tags)
                .FirstOrDefault(twit => twit.Id == id);
            var tags = tweet.Tags.ToList();
            foreach (var tag in tags)
            {
                db.Tags.Delete(tag);
            }

            db.Tweets.Delete(tweet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool CheckAdminRole()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.All().FirstOrDefault(u => u.Id == userId);
            return user.Roles.Any(r => r.Role.Name == "Admin");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
