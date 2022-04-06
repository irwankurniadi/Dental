using AutoMapper;
using DentalApps.API.DAL.Interface;
using DentalApps.Models;
using DentalApps.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DentalApps.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatients _patients;
        private readonly IMapper _mapper;

        public PatientsController(IPatients patients,IMapper mapper)
        {
            _patients = patients;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientReadDto>>> GetAll()
        {
            var results = await _patients.GetAll(); 
            var patientReadDto = _mapper.Map<IEnumerable<PatientReadDto>>(results);
            return Ok(patientReadDto);
        }

        [HttpGet("{patientId}",Name = "GetById")]
        public async Task<ActionResult<PatientReadDto>> GetById(string patientId)
        {
            var patient = await _patients.GetById(patientId);
            if(patient==null) return NotFound();

            var patientReadDto = _mapper.Map<PatientReadDto>(patient);
            return Ok(patientReadDto);
        }

        [HttpPost]
        public async Task<ActionResult<PatientReadDto>> Create(PatientCreateDto patientCreateDto)
        {
            try
            {
                var newPatient = _mapper.Map<Patient>(patientCreateDto);
                await _patients.Create(newPatient);
                var patientReadDto = _mapper.Map<PatientReadDto>(newPatient);
                return CreatedAtRoute(nameof(GetById), 
                    new { patientId=patientReadDto.PatientID },patientReadDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<PatientReadDto>> Update(string id,PatientCreateDto patientCreateDto)
        {
            try
            {
                var editPatient = _mapper.Map<Patient>(patientCreateDto);
                await _patients.Update(id,editPatient);
                var patientReadDto = _mapper.Map<PatientReadDto>(editPatient);
                return Ok(patientReadDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{patientId}")]
        public async Task<ActionResult> Delete(string patientId)
        {
            try
            {
                await _patients.Delete(patientId);
                return Ok($"Data {patientId} berhasil didelete !");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}