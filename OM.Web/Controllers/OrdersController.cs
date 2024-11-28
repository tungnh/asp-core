 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OM.Application.Models;
using OM.Application.Services.Interfaces;
using OM.Domain;
using OM.Infrastructure.Data;

namespace OM.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOrderService _orderService;
        public OrdersController(ApplicationDbContext context, IOrderService orderService)
        {
            _context = context;
            _orderService = orderService;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index([Bind("sort")]string sort)
        {
            var listOrder = await _orderService.GetAllAsync();
            if (sort == "1")
            {
                listOrder = listOrder.OrderByDescending(x => x.CreatedAt).ThenByDescending(x => x.LastModifiedAt).ToList();
                var json = JsonSerializer.Serialize(listOrder);
                return Json(json);
            }
            else
            {
                listOrder = listOrder.OrderBy(x=>x.CreatedAt).OrderBy(x=>x.LastModifiedAt).ToList();
                var json2 = JsonSerializer.Serialize(listOrder);
                return Json(json2);
            }
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id", "Amount", "UnitPrice", "Total", "ProductId")] OrderInputModel order)
        {
            await _orderService.AddAsync(order, "1");
            var jsonData = new { Message = "Success" };
            return Json(jsonData);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "Amount", "UnitPrice", "Total", "ProductId")] OrderInputModel order)
        {
           await _orderService.UpdateAsync(order, id.ToString());
            return RedirectToAction(nameof(Index));
        }

       
        // POST: Orders/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
