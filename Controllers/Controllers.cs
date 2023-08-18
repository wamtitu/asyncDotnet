using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wk3Assesment.Models;
using Newtonsoft.Json;


namespace wk3Assesment.Controllers
{
    public class Controllers
    {
        public async Task GetUsers()
        {
            HttpClient httpClient = new HttpClient();

            string Url = "https://jsonplaceholder.typicode.com/users";

            var response = await httpClient.GetAsync(Url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                
                var users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Users>>(responseBody);                
                // display users
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.id}. Username: {user.username}");

                }
            }else {
                System.Console.WriteLine("no users found");
            }
            Console.WriteLine("select whose posts you wish to view");
            var id = Console.ReadLine();
             await GetPostsForUser(id);
        }
        public async Task GetPostsForUser(string userId)
        {
            Console.WriteLine($"getting posts for user {userId}");
            System.Console.WriteLine("============================================");
            Console.ForegroundColor= ConsoleColor.Yellow;
            HttpClient httpClient = new HttpClient();

            string url = $"https://jsonplaceholder.typicode.com/posts?userId={userId}";


            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                
                var posts = JsonConvert.DeserializeObject<List<Posts>>(responseBody);

                foreach (var post in posts)
                {
                    Console.WriteLine($"{post.id}.    user email: {post.title},  content: {post.body}");
                }
            }
            else
            {
                Console.WriteLine("Error fetching posts.");
            }
            System.Console.WriteLine("============================================");
            Console.WriteLine("select post you wish to view comments");
            var id = Console.ReadLine();
           await GetCommetsForPosts(id);
        }
        public async Task GetCommetsForPosts(string id)
        {
          Console.ForegroundColor= ConsoleColor.Green;
            System.Console.WriteLine($"getting comments for post {id}");
            System.Console.WriteLine("============================================");
            HttpClient httpClient = new HttpClient();

            string url = $"https://jsonplaceholder.typicode.com/comments?postId={id}";


            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                
                var comments = JsonConvert.DeserializeObject<List<Comments>>(responseBody);

                foreach (var comment in comments)
                {
                    Console.WriteLine($"{comment.id}.    useremail: {comment.email},  name: {comment.name},  content: {comment.body}");
                }
            }
            else
            {
                Console.WriteLine("Error fetching posts.");
            }
            System.Console.WriteLine("============================================");
            System.Console.WriteLine("================================");
            Console.WriteLine("THANK YOU FOR USING POSTIT");
        }
    }
}