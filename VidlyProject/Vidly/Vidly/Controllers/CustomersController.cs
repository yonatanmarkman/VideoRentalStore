using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Caching;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class CustomersController : Controller
	{
		private ApplicationDbContext _context;
		
		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}


		// This function loads the CustomerForm without an existing customer.
		// So that the form is empty, and there's no Id transferred.
		// So when the form is submitted, the Save function adds the new customer to the DB.
		public ActionResult New()
		{
			var membershipTypes = _context.MembershipTypes.ToList();
			var viewModel = new CustomerFormViewModel
			{
				Customer = new Customer(), // This is needed, so that Id won't be null in the View.
				MembershipTypes = membershipTypes
			};

			return View("CustomerForm", viewModel);
		}

		public ActionResult CustomerForm()
		{
			return RedirectToAction("New", "Customers");
		}

        static string Genres = "Genres";

		public ViewResult Index()
		{
            // .ToList() makes the query be executed immediately, and returns the result,
            // if it was without .ToList(), it would be "deferred execution" - the list would be
            // built only when we start going over it, to print it in the CSHTML.

            // .Include() does Eager Loading - loads the MembershipType object together with the Customer object.
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            
            /*
            if (MemoryCache.Default[Genres] == null)
            {
                MemoryCache.Default[Genres] = _context.Genres.ToList();
            }

            var genres = MemoryCache.Default[Genres] as IEnumerable<Genre>;
            */

            return View();
		}

		// GET: Customers/Details/1
		public ActionResult Details(int id)
		{
			// .SingleOrDefault executes the query immediately
			var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(item => item.Id == id);
			if (customer == null)
				return new HttpNotFoundResult("Not Found");

			return View(customer);
		}

		public ActionResult Edit(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null)
			{
				return HttpNotFound();
			}

			var viewModel = new CustomerFormViewModel
			{
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
			};

			// Specify the view name, otherwise MVC will look for a view called Edit.
			// Also, pass the viewModel for the specified view.
			return View("CustomerForm", viewModel);
		}

		// If an action modifies data,
		// it should never be accessed via Http Get.
		// This function binds the data from the form,
		// to the customer function argument .
		// *The object is checked based on the data annotations of it's class.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Customer customer)
		{
			// Access to validation data
			if (!ModelState.IsValid)
			{
				var viewModel = new CustomerFormViewModel
				{
					Customer = customer,
					MembershipTypes = _context.MembershipTypes.ToList()
				};
				return View("CustomerForm", viewModel); // Invalid state returns the same view
			}

			if (customer.Id == 0)
			{
				_context.Customers.Add(customer); // Does not affect DB, needs to be saved to affect DB.
			}
			else
			{
				// Get the entity from DB
				var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

				// TryUpdateModel(customerInDb); - Not a secure way of updating.

				customerInDb.Name = customer.Name;
				customerInDb.Birthdate = customer.Birthdate;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			}

			_context.SaveChanges(); // Saves the changes to the DB.

			return RedirectToAction("Index", "Customers");
		}
	}
}