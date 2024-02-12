using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCIntroDemo.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCIntroDemo.Infrastructure.Data.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        private Post[] initialPosts = new Post[]
        {
            new Post
            {
                Id = 1,
                Title = "First Post",
                Content = "This is the first post in the blog."
            },
            new Post
            {
                Id = 2,
                Title = "Second Post",
                Content = "This is the second post in the blog."
            }
        };
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(initialPosts);
        }
    }
}
