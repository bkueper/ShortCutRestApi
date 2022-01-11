using Microsoft.AspNetCore.Mvc;
using ShortCutApi.dtos;
using ShortCutApi.Models;
using ShortCutApi.Controllers;
using ShortCutApi.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShortCutApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachinesController: ControllerBase
    {
        private readonly ShortCutContext _db;

        public MachinesController(ShortCutContext context)
        {
            _db = context;
        }
        
        [HttpPost]
        public IActionResult CreateMachine(CreateMachineDto createMachineDto){
            if(_db.Customers.SingleOrDefault(c => c.CustomerId == createMachineDto.customerId) == null){
                return NotFound("Customer ID does not exist.");
            }
            Machine machine = new()
            {
                SerialNumber = createMachineDto.SerialNumber,
                MachineName = createMachineDto.MachineName,
                url = createMachineDto.url,
                customer = _db.Customers.SingleOrDefault(c => c.CustomerId == createMachineDto.customerId)
                
            };
            _db.Machines.Add(machine);
            _db.SaveChanges();

            return CreatedAtAction("GetMachine", new {id = machine.MachineId}, machine);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMachine(int id){
            var machineFromDb = _db.Machines.Include(m => m.customer).SingleOrDefault(m => m.MachineId == id);
            if(machineFromDb == null)
            {
                return NotFound();
            }
            return Ok(machineFromDb);
            
        }
        [HttpGet]
        [Route("GetAllMachines")]
        public IActionResult GetAllMachines(){
            var allMachines = _db.Machines.Include(m => m.customer).ToList();
            if(allMachines.Count == 0)
            {
                return Ok("No Machines in Database");
            }
            return Ok(allMachines);
            
        }
        [HttpPut]
        public IActionResult Updatemachine(Machine machine){
            Machine machineFromDb = _db.Machines.SingleOrDefault(m => m.MachineId == machine.MachineId);
            if (machineFromDb == null){
                return NotFound();
            }

            machineFromDb.MachineName = machine.MachineName;
            machineFromDb.SerialNumber = machine.SerialNumber;
            machineFromDb.customer = machine.customer;
            machineFromDb.url = machine.url;

            _db.SaveChanges();

            return Ok("Changed Machine succesfully");

        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteMachine(int id){
            Machine machineFromDb = _db.Machines.SingleOrDefault(m => m.MachineId == id);

            if(machineFromDb == null){
                return NotFound();
            }
            _db.Remove(machineFromDb);
            _db.SaveChanges();

            return Ok("Deleted Machine Successfully");
        }
    }
}

        /*public MachinesController(IMachineRepository machineRepository, ICustomerRepository customerRepository)
        {
            _machineRepository = machineRepository;
            _customerRepository = customerRepository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MachineRepository>> GetMachine(int id){
            var machine = await _machineRepository.Get(id);
            if(machine == null)
                return NotFound();

            return Ok(machine);
        }
        /*
        [HttpGet("{id}")]
        [Route("customerFromMachineId")]
        public async Task<ActionResult<MachineRepository>> GetCustomerFromMachineId(int id){
            var machine = await _machineRepository.Get(id);
            if (machine == null)
                return NotFound();

            return Ok(machine.customer);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MachineRepository>>> GetMachines(){
            var machines = await _machineRepository.GetAll();
            return Ok(machines);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMachine(CreateMachineDto createMachineDto){
            Machine machine = new()
            {
                SerialNumber = createMachineDto.SerialNumber,
                MachineName = createMachineDto.MachineName,
                url = createMachineDto.url,
                customer = await _customerRepository.Get(createMachineDto.customerId)
            };

            await _machineRepository.Add(machine);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteMachine(int id){
            await _machineRepository.Delete(id);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> UpdateMachine(int id, UpdateMachineDto updateMachineDto){
            Machine machine = new()
            {   
                MachineId = id,
                SerialNumber = updateMachineDto.SerialNumber,
                MachineName = updateMachineDto.MachineName,
                url = updateMachineDto.url,
                customer = await _customerRepository.Get(updateMachineDto.customerId)
            };
            await _machineRepository.Update(machine);

            return Ok();
        }
    }
*/

