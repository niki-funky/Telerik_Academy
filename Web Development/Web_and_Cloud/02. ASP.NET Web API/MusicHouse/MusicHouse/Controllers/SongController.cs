﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MusicHouse.Models;
using MusicHouse.Context;

namespace MusicHouse.Controllers
{
    public class SongController : ApiController
    {
        private MusicHouseContext db = new MusicHouseContext();

        // GET api/Song
        public IEnumerable<Song> GetSongs()
        {
            return db.Songs.AsEnumerable();
        }

        // GET api/Song/5
        public Song GetSong(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return song;
        }

        // PUT api/Song/5
        public HttpResponseMessage PutSong(int id, Song song)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != song.SongId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(song).State = EntityState.Modified;

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

        // POST api/Song
        public HttpResponseMessage PostSong(Song song)
        {
            if (ModelState.IsValid)
            {
                db.Songs.Add(song);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, song);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = song.SongId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Song/5
        public HttpResponseMessage DeleteSong(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Songs.Remove(song);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, song);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}