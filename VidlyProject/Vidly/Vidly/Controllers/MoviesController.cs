using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		// GET: Movies/
		public ViewResult Index()
		{
			//var movies = _context.Movies.Include(m => m.Genre).ToList();

			return View();
		}

		// GET: Movies/Details/1
		public ActionResult Details(int id)
		{
			// .SingleOrDefault executes the query immediately
			var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(item => item.Id == id);
			if (movie == null)
				return new HttpNotFoundResult("Not Found");

			return View(movie);
		}

		// GET: Customers/Edit/1
		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movie == null)
			{
				return HttpNotFound();
			}

			var viewModel = new MovieFormViewModel(movie)
			{
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm", viewModel);
		}

		public ActionResult New()
		{
			var genres = _context.Genres.ToList();
			var viewModel = new MovieFormViewModel
			{
				//Movie = new Movie(),
				Genres = genres
			};

			// Q: What's the difference between this and View(viewModel) ?
			return View("MovieForm", viewModel);
		}

		public ActionResult MovieForm()
		{
			return RedirectToAction("New", "Movies");
		}

		// Used to save changes in Customer to DB.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new MovieFormViewModel(movie)
				{
					Genres = _context.Genres.ToList()
				};
				return View("MovieForm", viewModel);
			}

			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				_context.Movies.Add(movie);
			}
			else
			{
				var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

				movieInDb.Name = movie.Name;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.GenreId = movie.GenreId;
				movieInDb.NumberInStock = movie.NumberInStock;
			}

			_context.SaveChanges();
			
			return RedirectToAction("Index", "Movies");
		}
	}
}