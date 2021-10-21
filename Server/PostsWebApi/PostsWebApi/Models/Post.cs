using System;
using System.ComponentModel.DataAnnotations;

namespace PostsWebApi
{
    public class Post
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PublishDate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Range(0, int.MaxValue)]
        public int LikesCount { get; set; }

        [DataType(DataType.Text)]
        public string TextContent { get; set; }
    }
}
