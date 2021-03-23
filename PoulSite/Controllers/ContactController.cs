using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoulSite.Data;
using PoulSite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PoulSite.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.ContactForm.ToList();
            return View(list);
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateContact(ContactForm record)
        {
            var item = new ContactForm()
            {
                FirstName = record.FirstName,
                LastName = record.LastName,
                MobileNumber = record.MobileNumber,
                EmailAddress = record.EmailAddress,
                DateofBirth = record.DateofBirth,
                Gender = record.Gender,
                Region = record.Region,
                Province = record.Province,
                City = record.City,
                PostalCode = record.PostalCode,
                Barangay = record.Barangay,
                CompleteAddress = record.CompleteAddress
            };

            _context.ContactForm.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult EditContact(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var item = _context.ContactForm.Where(i => i.CustNo == id).SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult EditContact(int? id, ContactForm record)
        {
            var item = _context.ContactForm.Where(i => i.CustNo == id).SingleOrDefault();
            item.FirstName = record.FirstName;
            item.LastName = record.LastName;
            item.MobileNumber = record.MobileNumber;
            item.EmailAddress = record.EmailAddress;
            item.DateofBirth = record.DateofBirth;
            item.Gender = record.Gender;
            item.Region = record.Region;
            item.Province = record.Province;
            item.City = record.City;
            item.PostalCode = record.PostalCode;
            item.Barangay = record.Barangay;
            item.CompleteAddress = record.CompleteAddress;

            _context.ContactForm.Update(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteContact(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var item = _context.ContactForm.Where(i => i.CustNo == id).SingleOrDefault();
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            _context.ContactForm.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
