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
using Forum.Model;
using DataLayer;

namespace Forum.WebAPI.Controllers
{
    public class ThreadTestController : ApiController
    {
        private ForumContext db = new ForumContext();

        // GET api/ThreadTest
        public IEnumerable<Thread> GetThreads()
        {
            return db.Threads.AsEnumerable();
        }

        // GET api/ThreadTest/5
        public Thread GetThread(int id)
        {
            Thread thread = db.Threads.Find(id);
            if (thread == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return thread;
        }

        // PUT api/ThreadTest/5
        public HttpResponseMessage PutThread(int id, Thread thread)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != thread.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(thread).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/ThreadTest
        public HttpResponseMessage PostThread(Thread thread)
        {
            if (ModelState.IsValid)
            {
                db.Threads.Add(thread);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, thread);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = thread.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/ThreadTest/5
        public HttpResponseMessage DeleteThread(int id)
        {
            Thread thread = db.Threads.Find(id);
            if (thread == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Threads.Remove(thread);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, thread);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}