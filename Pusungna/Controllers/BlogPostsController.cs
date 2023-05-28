using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pusungna.Data;
using Pusungna.Models;
using Microsoft.EntityFrameworkCore;

namespace Pusungna.Controllers
{
  public class BlogPostsController : Controller
  {
    private readonly ApplicationDbContext _context;

    public BlogPostsController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: BlogPosts
    public IActionResult Index()
    {
      return View(_context.BlogPosts.ToList());
    }

    // GET: BlogPosts/Details/5
    public IActionResult Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var blogPost = _context.BlogPosts.FirstOrDefault(m => m.BlogPostId == id);
      if (blogPost == null)
      {
        return NotFound();
      }

      return View(blogPost);
    }

    // GET: BlogPosts/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: BlogPosts/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("BlogPostId,Title,Content,UserId")] BlogPost blogPost)
    {
      if (ModelState.IsValid)
      {
        _context.Add(blogPost);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
      }
      return View(blogPost);
    }

    // GET: BlogPosts/Edit/5
    public IActionResult Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var blogPost = _context.BlogPosts.Find(id);
      if (blogPost == null)
      {
        return NotFound();
      }
      return View(blogPost);
    }

    // POST: BlogPosts/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("BlogPostId,Title,Content,UserId")] BlogPost blogPost)
    {
      if (id != blogPost.BlogPostId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(blogPost);
          _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!BlogPostExists(blogPost.BlogPostId))
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
      return View(blogPost);
    }

    // GET: BlogPosts/Delete/5
    public IActionResult Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var blogPost = _context.BlogPosts.FirstOrDefault(m => m.BlogPostId == id);
      if (blogPost == null)
      {
        return NotFound();
      }

      return View(blogPost);
    }

    // POST: BlogPosts/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
      var blogPost = _context.BlogPosts.Find(id);
      if (blogPost == null)
      {
        return NotFound();
      }
      _context.BlogPosts.Remove(blogPost);
      _context.SaveChanges();
      return RedirectToAction(nameof(Index));
    }

    private bool BlogPostExists(int id)
    {
      return _context.BlogPosts.Any(e => e.BlogPostId == id);
    }
  }
}
