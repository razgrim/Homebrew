using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlbumShare2.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using Newtonsoft.Json;

namespace AlbumShare2.Models
{
    public class InitData
    {
        //Data initialization
        //https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-2.2&tabs=visual-studio

        static readonly string userDataURL = "https://jsonplaceholder.typicode.com/users";
        static readonly string postDataURL = "https://jsonplaceholder.typicode.com/posts";
        static readonly string albumDataURL = "https://jsonplaceholder.typicode.com/albums";
        static readonly string photoDataURL = "https://jsonplaceholder.typicode.com/photos";

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SiteContext(
                serviceProvider.GetRequiredService<DbContextOptions<SiteContext>>()))
            {
                // Look for any users.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }
                initUsers(context);
                initPosts(context);
                initAlbums(context);
                initPhotos(context);
                context.SaveChanges();
            }
        }

        public static string getWebpage(string url)
        {
            WebClient wc = new WebClient();
            return wc.DownloadString(url);
        }
        public static void initUsers(SiteContext context)
        {
            try
            {
                string rawJson = getWebpage(userDataURL);
                dynamic userList = JsonConvert.DeserializeObject(rawJson);
                User tempUser;
                foreach (var user in userList)
                {
                    tempUser = new User { Id = user.id, name = user.name, email = user.email, phone = user.phone };
                    tempUser.address = user.address.street + Environment.NewLine +
                        user.address.suite + Environment.NewLine +
                        user.address.city + ", " + user.address.zipcode;
                    context.Users.Add(tempUser);
                }
            }
            catch
            {
                //Couldn't get JSON from site, parhaps expected JSON format mismatch?
            }
        }

        public static void initPosts(SiteContext context)
        {
            try
            {
                string rawJson = getWebpage(postDataURL);
                dynamic postList = JsonConvert.DeserializeObject(rawJson);
                Post tempPost;
                foreach (var post in postList)
                {
                    tempPost = new Post { Id = post.id, UserID = post.userId, body=post.body, title=post.title };
                    context.Posts.Add(tempPost);
                }
            }
            catch
            {
                //Couldn't get JSON from site, parhaps expected JSON format mismatch?
            }
        }

        public static void initAlbums(SiteContext context)
        {
            try
            {
                string rawJson = getWebpage(albumDataURL);
                dynamic albumList = JsonConvert.DeserializeObject(rawJson);
                Album tempAlbum;
                foreach (var album in albumList)
                {
                    tempAlbum = new Album { Id = album.id, UserID = album.userId, title = album.title };
                    context.Albums.Add(tempAlbum);
                }
            }
            catch
            {
                //Couldn't get JSON from site, parhaps expected JSON format mismatch?
            }
        }

        public static void initPhotos(SiteContext context)
        {
            try
            {
                string rawJson = getWebpage(photoDataURL);
                dynamic photoList = JsonConvert.DeserializeObject(rawJson);
                Photo tempPhoto;
                foreach (var photo in photoList)
                {
                    tempPhoto = new Photo { Id = photo.id, AlbumID = photo.albumId, url = photo.url, tumbnailUrl=photo.thumbnailUrl };
                    context.Photos.Add(tempPhoto);
                }
            }
            catch
            {
                //Couldn't get JSON from site, parhaps expected JSON format mismatch?
            }
        }
    }
}
