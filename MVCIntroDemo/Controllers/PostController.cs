using Microsoft.AspNetCore.Mvc;
using MVCIntroDemo.Core.Contracts;
using MVCIntroDemo.Core.Models;

namespace MVCIntroDemo.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;
        public PostController(IPostService _postService)
        {
            postService = _postService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<PostModels> model = await postService.GetAllPostsAsync();
            return View(model);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new PostModels();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(PostModels model)
        {
            if (ModelState.IsValid==false)
            {
                return View(model);
            }
            await postService.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await postService.GetPostByIdAsync(id);
            if (model == null)
            {
                ModelState.AddModelError("All", "Invalid post");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PostModels model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await postService.EditAsync(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await postService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
