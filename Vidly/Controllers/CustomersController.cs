using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Contexts;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customers;
        DBContext _context;

        public CustomersController()
        {
            _context = new DBContext();
            customers = _context.Customers.Include(c => c.membershipType).ToList();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = customers.SingleOrDefault(c => c.id == id);

            if (customer != null)
                return View(customer);

            return HttpNotFound();
        }

        public ActionResult Add()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                customer = new Customer(),
                membershipTypes = membershipTypes,
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    customer = customer,
                    membershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.id == customer.id);
                customerInDb.name = customer.name;
                customerInDb.birthdate = customer.birthdate;
                customerInDb.membershipTypeId = customer.membershipTypeId;
                customerInDb.isSubscribedToNewsletter = customer.isSubscribedToNewsletter;
            }

            _context.SaveChanges();
            return RedirectToAction("index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                customer = customer,
                membershipTypes = _context.MembershipTypes.ToList(),
            };

            return View("CustomerForm", viewModel);
        }
    }

}