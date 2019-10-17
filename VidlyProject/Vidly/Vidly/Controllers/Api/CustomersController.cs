using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
	public class CustomersController : ApiController
	{
		private ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		// GET /api/customers
		public IHttpActionResult GetCustomers()
		{
			// The select method is used to map the Customer objects to CustomerDto
			return Ok(_context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>));
		}

		// GET /api/customers/1
		public IHttpActionResult GetCustomer(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return NotFound();

			return Ok(Mapper.Map<Customer, CustomerDto>(customer));
		}

		// POST /api/customers
		// The object will be in the request body,
		// and the Web API will automatically initialize it.
		[HttpPost]
		public IHttpActionResult CreateCustomer(CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
			_context.Customers.Add(customer);
			_context.SaveChanges();

			customerDto.Id = customer.Id;

			// Request.RequestUri in this case is api/customers
			return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
		}

		// PUT /api/customers/1
		// id is read from the URL
		// customer comes from the request body
		[HttpPut]
		public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customerInDb == null)
				return NotFound();

			//Update customerInDb
			Mapper.Map(customerDto, customerInDb);

			_context.SaveChanges();

			return Ok();
		}

		// DELETE /api/customers/1
		[HttpDelete]
		public IHttpActionResult DeleteCustomer(int id)
		{
			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customerInDb == null)
				return NotFound();

			_context.Customers.Remove(customerInDb);
			_context.SaveChanges();

			return Ok();
		}
	}
}
