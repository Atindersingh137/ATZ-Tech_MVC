using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATZ_Tech_MVC.Data;
using ATZ_Tech_MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace ATZ_Tech_MVC.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
       
        private readonly ATZ_Tech_MVCContext _context;

        public ATZ_Tech_MVCContext Context => _context;

        public OrdersController(ATZ_Tech_MVCContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var aTZ_Tech_MVCContext = Context.Order.Include(o => o.Product).Include(o => o.User);
            return View(await aTZ_Tech_MVCContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await Context.Order
                .Include(o => o.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(Context.Product, "ID", "Name");
            ViewData["UserID"] = new SelectList(Context.User, "ID", "FirstName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,ProductID")] Order order)
        {
            if (ModelState.IsValid)
            {
                Context.Add(order);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(Context.Product, "ID", "Name", order.ProductID);
            ViewData["UserID"] = new SelectList(Context.User, "ID", "FirstName", order.UserID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await Context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(Context.Product, "ID", "Name", order.ProductID);
            ViewData["UserID"] = new SelectList(Context.User, "ID", "FirstName", order.UserID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,ProductID")] Order order)
        {
            if (id != order.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Context.Update(order);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.ID))
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
            ViewData["ProductID"] = new SelectList(Context.Product, "ID", "Name", order.ProductID);
            ViewData["UserID"] = new SelectList(Context.User, "ID", "FirstName", order.UserID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await Context.Order
                .Include(o => o.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await Context.Order.FindAsync(id);
            Context.Order.Remove(order);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return Context.Order.Any(e => e.ID == id);
        }
    }
}
