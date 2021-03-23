using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PoulSite.Data;
using PoulSite.Models;

namespace PoulSite.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Orders.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Orders record)
        {
            var item = new Orders()
            {
                OrderLists = record.OrderLists,
                Name = record.Name,
                ContactNo = record.ContactNo,
                Address = record.Address,
                DateTimeOrdered = record.DateTimeOrdered,
                TotalPrice = record.TotalPrice,
                DateAdded = DateTime.Now,
                Notes = record.Notes,
                MOP = record.MOP
            };

            _context.Orders.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var item = _context.Orders.Where(i => i.OrderNo == id).SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(int? id, Orders record)
        {
            var item = _context.Orders.Where(i => i.OrderNo == id).SingleOrDefault();
            item.OrderLists = record.OrderLists;
            item.Name = record.Name;
            item.ContactNo = record.ContactNo;
            item.Address = record.Address;
            item.DateTimeOrdered = record.DateTimeOrdered;
            item.TotalPrice = record.TotalPrice;
            item.DateAdded = DateTime.Now;
            item.Notes = record.Notes;
            item.MOP = record.MOP;

            _context.Orders.Update(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var item = _context.Orders.Where(i => i.OrderNo == id).SingleOrDefault();
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            _context.Orders.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
