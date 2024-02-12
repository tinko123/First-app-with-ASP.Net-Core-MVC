using MVCIntroDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCIntroDemo.Core.Contracts
{
    public interface IPostService
    {
        Task AddAsync(PostModels model);
        Task DeleteAsync(int id);
        Task EditAsync(PostModels model);
        Task<IEnumerable<PostModels>> GetAllPostsAsync();
        Task<PostModels?> GetPostByIdAsync(int id);
    }
}
