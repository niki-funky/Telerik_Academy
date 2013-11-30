using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using MusicHouse.Context;
using MusicHouse.Models;

namespace MusicHouse.Client
{
    class Program
    {
        static string baseUrl = "http://localhost:61428/api";

        static void Main(string[] args)
        {
            // run only once
            #region fill database with data

            //using (var context = new MusicHouseContext())
            //{
            //    #region songs
            //    var song1 = new Song();
            //    song1.Title = "song1";
            //    song1.Genre = "metal";
            //    context.Songs.Add(song1);

            //    var song2 = new Song();
            //    song2.Title = "song2";
            //    song2.Genre = "metal";
            //    context.Songs.Add(song2);
            //    #endregion

            //    #region artists
            //    var artist1 = new Artist();
            //    artist1.Name = "Metalica";
            //    artist1.Country = "us";
            //    artist1.Songs = new List<Song>();
            //    artist1.Songs.Add(song1);
            //    artist1.Songs.Add(song2);
            //    context.Artists.Add(artist1);

            //    var artist2 = new Artist();
            //    artist2.Name = "Manowar";
            //    artist2.Country = "bg";
            //    artist2.Songs = new List<Song>();
            //    artist2.Songs.Add(song1);
            //    artist2.Songs.Add(song2);
            //    context.Artists.Add(artist2);
            //    #endregion

            //    #region albums
            //    var album1 = new Album();
            //    album1.Title = "album-black";
            //    album1.ReleaseDate = new DateTime(1986, 10, 20);
            //    album1.Producer = "virginia-records";
            //    album1.Artists = new List<Artist>();
            //    album1.Artists.Add(artist1);
            //    album1.Songs = new List<Song>();
            //    album1.Songs.Add(song1);
            //    album1.Songs.Add(song2);
            //    context.Albums.Add(album1);

            //    var album2 = new Album();
            //    album2.Title = "album-white";
            //    album2.ReleaseDate = new DateTime(1986, 10, 20);
            //    album2.Producer = "virginia-records";
            //    album2.Artists = new List<Artist>();
            //    album2.Artists.Add(artist1);
            //    album2.Artists.Add(artist2);
            //    album2.Songs = new List<Song>();
            //    album2.Songs.Add(song1);
            //    album2.Songs.Add(song2);
            //    context.Albums.Add(album2);
            //    #endregion

            //    context.SaveChanges();
            //}

            #endregion

            ManageData manageData = new ManageData(baseUrl);

            // uncomment to test 
            // same code is for songs and artists
            // with the appropriate checks for existing constraints

            #region GET

            var responseGet = manageData.Get("/album");
            if (responseGet.IsSuccessStatusCode)
            {
                var albums = responseGet.Content.
                    ReadAsAsync<IEnumerable<Album>>().Result;
                foreach (var a in albums)
                {
                    Console.WriteLine("{0,4} {1,-20} {2}",
                        a.AlbumId, a.Title, a.ReleaseDate);
                    if (a.Artists != null)
                    {
                        foreach (var artist in a.Artists)
                        {
                            Console.WriteLine("artist name: {0} {1} {2}",
                                artist.Name, artist.Country, artist.DateOfBirth);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})",
                    (int)responseGet.StatusCode, responseGet.ReasonPhrase);
            }

            #endregion

            #region PUT

            //
            var newAlbum = new Album();
            newAlbum.AlbumId = 1;
            newAlbum.Title = "album-red";
            newAlbum.ReleaseDate = new DateTime(2000, 9, 9);
            newAlbum.Producer = "niki";
            //
            var newArtist = new Artist();
            newArtist.ArtistId = 1;
            //
            newAlbum.Artists = new List<Artist>();
            newAlbum.Artists.Add(newArtist);

            var responsePut = manageData.UpdateAsJson<Album>(newAlbum, "/album", newAlbum.AlbumId);
            if (responsePut.IsSuccessStatusCode)
            {
                Console.WriteLine("Album updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})",
                    (int)responsePut.StatusCode, responsePut.ReasonPhrase);
            }

            #endregion

            #region POST

            var newAlbum2 = new Album();
            newAlbum2.Title = "album-orange";
            newAlbum2.ReleaseDate = new DateTime(1999, 10, 20);
            newAlbum2.Producer = "sony-records";

            #region create as JSON
            
            var responsePostJSON = manageData.CreateAsJson<Album>(newAlbum2, "/Album");
            if (responsePostJSON.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added as JSON!");
            }
            else
            {
                Console.WriteLine("{0} ({1})",
                    (int)responsePostJSON.StatusCode, responsePostJSON.ReasonPhrase);
            } 

            #endregion

            #region create as XML

            var responsePostXML = manageData.CreateAsXML<Album>(newAlbum2, "/Album");
            if (responsePostXML.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added as XML!");
            }
            else
            {
                Console.WriteLine("{0} ({1})",
                    (int)responsePostXML.StatusCode, responsePostXML.ReasonPhrase);
            } 

            #endregion

            #endregion

            #region DELETE

            //var albumId = 2;

            //HttpResponseMessage responseDel = manageData.Delete("/Album", albumId);
            //if (responseDel.IsSuccessStatusCode)
            //{
            //    Console.WriteLine("Album with id: {0} deleted successfully!", albumId);
            //}
            //else
            //{
            //    Console.WriteLine("{0} ({1})",
            //        (int)responseDel.StatusCode, responseDel.ReasonPhrase);
            //}

            #endregion
        }
    }
}
