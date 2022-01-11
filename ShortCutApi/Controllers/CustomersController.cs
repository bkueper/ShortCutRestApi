using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShortCutApi.Data;
using ShortCutApi.dtos;
using ShortCutApi.Models;

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
        /*
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerRepository>> GetCustomer(int id){
            var customer = await _customerRepository.Get(id);
            if(customer == null)
                return NotFound();

            return Ok(customer);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerRepository>>> GetCustomers(){
            var customers = await _customerRepository.GetAll();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMachine(CreateCustomerDto createCustomerDto){
            Customer customer = new()
            {
                Name = createCustomerDto.Name,
                phonenumber = createCustomerDto.phonenumber,
                EMail = createCustomerDto.EMail,
                Adress = createCustomerDto.Adress
            };

            await _customerRepository.Add(customer);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteCustomer(int id){
            await _customerRepository.Delete(id);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(int id, UpdateCustomerDto updateCustomerDto){
            Customer customer = new()
            {   
                CustomerId = id,
                Name = updateCustomerDto.Name,
                phonenumber = updateCustomerDto.phonenumber,
                EMail = updateCustomerDto.EMail,
                Adress = updateCustomerDto.Adress
            };
            await _customerRepository.Update(customer);

            return Ok();
        }
        */
    }
}