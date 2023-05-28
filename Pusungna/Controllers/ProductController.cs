using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pusungna.Models;
using Pusungna.Data;
using Microsoft.EntityFrameworkCore;

namespace Pusungna.Controllers
{
  public class ProductsController : Controller
  {
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: Products
    public IActionResult Index()
    {
      return View(_context.Products.ToList());
    }

    // GET: Products/Details/5
    public IActionResult Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var product = _context.Products.FirstOrDefault(m => m.ProductId == id);
      if (product == null)
      {
        return NotFound();
      }

      return View(product);
    }

    // GET: Products/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Products/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Id,Name,Description,Price,ImageUrl")] Product product)
    {
      if (ModelState.IsValid)
      {
        _context.Add(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
      }
      return View(product);
    }

    // GET: Products/Edit/5
    public IActionResult Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var product = _context.Products.Find(id);
      if (product == null)
      {
        return NotFound();
      }
      return View(product);
    }

    // POST: Products/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id,Name,Description,Price,ImageUrl")] Product product)
    {
      if (id != product.ProductId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(product);
          _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ProductExists(product.ProductId))
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
      return View(product);
    }

    // GET: Products/Delete/5
    public IActionResult Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var product = _context.Products.FirstOrDefault(m => m.ProductId == id);
      if (product == null)
      {
        return NotFound();
      }

      return View(product);
    }

    // POST: Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
      var product = _context.Products.Find(id);
      if (product == null)
      {
        return NotFound();
      }

      _context.Products.Remove(product);
      _context.SaveChanges();
      return RedirectToAction(nameof(Index));
    }


    private bool ProductExists(int id)
    {
      return _context.Products.Any(e => e.ProductId == id);
    }
  }
}
