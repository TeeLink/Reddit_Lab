using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reddit_Lab.Models
{
    public class Post
    {
        public int UpVote { get; set; }
        public int DownVote { get; set; }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string Link { get; set; }
        [Required]
        public DateTime Posted { get; set; }
        public string Body { get; set; }
        public Comment Comment { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}