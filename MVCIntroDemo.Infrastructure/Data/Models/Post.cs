using Microsoft.EntityFrameworkCore;
using MVCIntroDemo.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCIntroDemo.Infrastructure.Data.Models
{
    public class Post
    {
        [Key]
        [Comment("Post primary key")]
        public int Id { get; set; }
        [Required]
        [MaxLength(ValidationConstants.PostTitleMaxLength)]
        [Comment("Title of the post")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(ValidationConstants.PostContentMaxLength)]
        [Comment("Content of the post")]
        public string Content { get; set; } = string.Empty;

    }
}
