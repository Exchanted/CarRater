using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRater.Data;
using CarRater.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CarRater.Controllers
{
    [Authorize] // Require a user to login when visitting the page
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PostsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Posts.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Posts posts = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posts == null)
            {
                return NotFound();
            }

            CommentsViewModel viewModel = await GetCommentsDetailsFromPosts(posts);

            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details([Bind("PostsID,Comment")] CommentsViewModel viewModel)
        {
            IdentityUser user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                Comments comments = new Comments();
                comments.Comment = viewModel.Comment;

                Posts posts = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == viewModel.PostsID);

                if (posts == null)
                {
                    return NotFound();
                }

                comments.UserId = user.Id;
                _context.Add(comments);

                comments.MyPosts = posts;
                _context.Comments.Add(comments);
                await _context.SaveChangesAsync();
                viewModel = await GetCommentsDetailsFromPosts(posts);

            }
            //Prevent User Refreshing webpage to Resend POST Request by Redirecting to Home
            return RedirectToAction("Index", "Posts");
        }

        private async Task<CommentsViewModel> GetCommentsDetailsFromPosts(Posts posts)
        {
            CommentsViewModel viewModel = new CommentsViewModel();

            viewModel.posts = posts;

            List<Comments> comments = await _context.Comments
                .Where(m => m.MyPosts == posts).ToListAsync();

            viewModel.Comments = comments;
            return viewModel;
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Link")] Posts posts)
        {
            IdentityUser user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                posts.UserId = user.Id;
                _context.Add(posts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(posts);
        }

        // GET: Posts/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await _context.Posts.FindAsync(id);
            if (posts == null)
            {
                return NotFound();
            }
            return View(posts);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Link")] Posts posts)
        {
            IdentityUser user = await _userManager.GetUserAsync(User);
            
            if (id != posts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    posts.UserId = user.Id;
                    _context.Add(posts);
                    _context.Update(posts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostsExists(posts.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(posts);
        }

        // GET: Posts/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);

            List<Comments> comments =  _context.Comments
                .Where(comment => comment.MyPosts.Id == id).ToList();

            foreach (Comments comment in comments)
            {
                _context.Comments.Remove(comment);
            }

            if (posts == null)
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();

            return View(posts);
        }

        // GET: Posts/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteComment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comments = await _context.Comments
                .FirstOrDefaultAsync(m => m.Id == id);

            if (comments == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Posts");
        }

        // POST: Posts/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posts = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(posts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostsExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
