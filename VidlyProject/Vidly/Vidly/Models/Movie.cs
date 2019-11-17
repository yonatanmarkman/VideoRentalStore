﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
	public class Movie
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Please enter movie name.")]
		[StringLength(255)]
		public string Name { get; set; }

		[Display(Name = "Release Date")]
		[Required]
		public DateTime ReleaseDate { get; set; }

		public DateTime DateAdded { get; set; }

		[Display(Name = "Number in Stock")]
		[Required]
		[Range(1, 20)]
		public byte NumberInStock { get; set; }

        [Required]
        [Range(0, 20)]
        public byte NumberAvailable { get; set; }

		public Genre Genre { get; set; }

		[Display(Name = "Genre")]
		[Required]
		public byte GenreId { get; set; }
	}

}