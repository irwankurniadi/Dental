using AutoMapper;
using DentalApps.API.DAL.Interface;
using DentalApps.Models;
using DentalApps.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DentalApps.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployees _employees;
        private readonly IMapper _mapper;
        
        public EmployeesController(IEmployees employees, IMapper mapper)
        {
            _employees = employees;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetAll()
        {
            var results = await _employees.GetAll(); 
            var employeeReadDto = _mapper.Map<IEnumerable<EmployeeReadDto>>(results);
            return Ok(employeeReadDto);
        }

        [HttpGet("{employeeId}",Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeReadDto>> GetEmployeeById(string employeeId)
        {
            var employee = await _employees.GetById(employeeId);
            if(employee==null) return NotFound();

            var employeeReadDto = _mapper.Map<EmployeeReadDto>(employee);
            return Ok(employeeReadDto);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeReadDto>> Create(EmployeeCreateDto employeeCreateDto)
        {
            try
            {
                var newEmployee = _mapper.Map<Employee>(employeeCreateDto);
                await _employees.Create(newEmployee);
                var employeeReadDto = _mapper.Map<EmployeeReadDto>(newEmployee);
                return CreatedAtRoute(nameof(GetEmployeeById), 
                    new { employeeId=employeeReadDto.EmployeeID },employeeReadDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeReadDto>> Update(string id,EmployeeCreateDto employeeCreateDto)
        {
            try
            {
                var editEmployee = _mapper.Map<Employee>(employeeCreateDto);
                await _employees.Update(id,editEmployee);
                var employeeReadDto = _mapper.Map<EmployeeReadDto>(editEmployee);
                return Ok(employeeReadDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{employeeId}")]
        public async Task<ActionResult> Delete(string employeeId)
        {
            try
            {
                await _employees.Delete(employeeId);
                return Ok($"Data {employeeId} berhasil didelete !");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}