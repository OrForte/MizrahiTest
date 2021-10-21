using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private Post[] posts = new Post[POST_COUNT];
        private static Random random = new Random();
        private const int POST_COUNT = 100;
        private const int DEFAULT_PAGE_SIZE = 10;

        public PostsController()
        {
            for (int i = 0; i < POST_COUNT; i++)
            {
                posts[i] = new Post
                {
                    PublishDate = DateTime.Now.AddDays(i),
                    LikesCount = random.Next(0, 200),
                    Username = GenerateRandomString(random.Next(0, 50)),
                    TextContent = GenerateRandomString(random.Next(0, 250)),
                };
            }
        }

        private static string GenerateRandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 ";
            var stringChars = new char[length];

            for (int i = 0; i < stringChars.Length; i++)
                stringChars[i] = chars[random.Next(chars.Length)];

            return new string(stringChars);
        }

        [HttpGet]
        public IEnumerable<Post> GetPosts()
        {
            return posts;
        }

        [Route("{pageNumber:min(1)}")]
        [HttpGet]
        public IEnumerable<Post> GetPosts(int pageNumber, int pageSize = DEFAULT_PAGE_SIZE)
        {
            return posts.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToArray();
        }
    }
}
