﻿using AutoMapper; //  install-package automapper -version:4.1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
	// This class is used to be able to map between
	// Customer and it's DTO, and vice versa.
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			// Domain to Dto
			Mapper.CreateMap<Customer, CustomerDto>();
			Mapper.CreateMap<Movie, MovieDto>();
			Mapper.CreateMap<MembershipType, MembershipTypeDto>();
			Mapper.CreateMap<Genre, GenreDto>();

			// Dto to Domain
			Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
			Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
		}
	}
}