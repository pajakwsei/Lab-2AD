﻿using LibApp.Data;
using LibApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AutoMapper;
using LibApp.Dtos;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public CustomersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET /api/customers
        [HttpGet]
        [Produces("application/xml")]
        public IActionResult GetCustomers()
        {
            return Ok(_context.Customers.ToList().Select(_mapper.Map<Customer, CustomerDto>));
        }

        // GET /api/customers/{id}
        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null) 
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Customers.Add(_mapper.Map<Customer>(customerDto));
            _context.SaveChanges();
            return CreatedAtRoute(nameof(GetCustomer), new { id = customerDto.Id }, customerDto);
        }

        // PUT /api/customers/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }

            _mapper.Map(customerDto, customerInDb);

            return Ok(customerDto);
        }

        // DELETE /api/customers/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok(customerInDb);
        }

        private ApplicationDbContext _context;
        private IMapper _mapper;
    }
}
