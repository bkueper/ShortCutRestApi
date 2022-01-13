using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShortCutApi.Data;
using ShortCutApi.dtos;
using ShortCutApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
namespace ShortCutApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController: ControllerBase
    {
       private readonly ShortCutContext _db;

        public CustomersController(ShortCutContext context)
        {
            _db = context;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer){
            _db.Customers.Add(customer);
            _db.SaveChanges();

            return CreatedAtAction("GetCustomer", new {id = customer.CustomerId}, customer);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCustomer(int id){
            Customer customerFromDb = _db.Customers.SingleOrDefault(c => c.CustomerId == id);
            if(customerFromDb == null)
            {
                return NotFound();
            }
            return Ok(customerFromDb);
            
        }
        [HttpGet]
        [Route("GetAllCustomers")]
        public IActionResult GetAllMachines(){
            var allCustomers = _db.Customers.ToList();
            if(allCustomers.Count == 0)
            {
                return Ok("No Machines in Database");
            }
            return Ok(allCustomers);
            
        }
        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer){
            Customer customerFromDb = _db.Customers.SingleOrDefault(c => c.CustomerId == customer.CustomerId);
            if (customerFromDb == null){
                return NotFound();
            }

            customerFromDb.Adress = customer.Adress;
            customerFromDb.EMail = customer.EMail;
            customerFromDb.Name = customer.Name;
            customerFromDb.phonenumber = customer.phonenumber;

            _db.SaveChanges();

            return Ok("Changed User succesfully");

        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBook(int id){
            Customer customerFromDb = _db.Customers.SingleOrDefault(c => c.CustomerId == id);

            if(customerFromDb == null){
                return NotFound();
            }
            _db.Remove(customerFromDb);
            _db.SaveChanges();

            return Ok("Deleted Machine Successfully");
        }
    }
}