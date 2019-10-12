using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
	public class MovieFormViewModel
	{
		//public Movie Movie { get; set; }

		// Copy relevant movie fields, to make it a pure ViewModel
		public int? Id { get; set; }

		[Required(ErrorMessage = "Please enter movie name.")]
		[StringLength(255)]
		public string Name { get; set; }

		[Display(Name = "Release Date")]
		[Required]
		public DateTime? ReleaseDate { get; set; }
		// If there is no '?', this property gets initialized in the View form.
		// '?' means that it starts with null. 
		
		[Display(Name = "Number in Stock")]
		[Required]
		[Range(1, 20)]
		public byte? NumberInStock { get; set; }


		[Display(Name = "Genre")]
		[Required]
		public byte? GenreId { get; set; }
		// WIP : check what happens if you remove '?'


		public IEnumerable<Genre> Genres { get; set; }

		public string PageTitle
		{
			get
			{
				return Id != 0 ? "Edit Movie" : "New Movie";
			}
		}

		public MovieFormViewModel()
		{
			Id = 0;
		}

		public MovieFormViewModel(Movie movie)
		{
			Id = movie.Id;
			Name = movie.Name;
			ReleaseDate = movie.ReleaseDate;
			NumberInStock = movie.NumberInStock;
			GenreId = movie.GenreId;
		}
	}
}