using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pusungna.Data;
using Pusungna.Models;
using Microsoft.EntityFrameworkCore;

namespace Pusungna.Controllers
{
  public class OrdersController : Controller
  {
    private readonly ApplicationDbContext _context;

    public OrdersController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: Orders
    public IActionResult Index()
    {
      return View(_context.Orders.ToList());
    }

    // GET: Orders/Details/5
    public IActionResult Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
      if (order == null)
      {
        return NotFound();
      }

      return View(order);
    }

    // GET: Orders/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Orders/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("OrderId,UserId")] Order order)
    {
      if (ModelState.IsValid)
      {
        _context.Add(order);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
      }
      return View(order);
    }

    // GET: Orders/Edit/5
    public IActionResult Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var order = _context.Orders.Find(id);
      if (order == null)
      {
        return NotFound();
      }
      return View(order);
    }

    // POST: Orders/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("OrderId,UserId")] Order order)
    {
      if (id != order.OrderId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        _context.Update(order);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
      }
      return View(order);
    }

    // GET: Orders/Delete/5
    public IActionResult Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
      if (order == null)
      {
        return NotFound();
      }

      return View(order);
    }

    // POST: Orders/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
      var order = _context.Orders.Find(id);
      if (order != null)
      {
        _context.Orders.Remove(order);
        _context.SaveChanges();
      }
      return RedirectToAction(nameof(Index));
    }

    private bool OrderExists(int id)
    {
      return _context.Orders.Any(e => e.OrderId == id);
    }
  }
}
