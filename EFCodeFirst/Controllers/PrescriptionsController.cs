using EFCodeFirst.Dtos;
using EFCodeFirst.Repositories.Abstractions;
using EFCodeFirst.Repositories.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCodeFirst.Controllers;

[Route("api/[controller]")]
public class PrescriptionsController(IPatientRepository patientRepository, IMedicamentRepository medicamentRepository, IPrescriptionRepository prescriptionRepository) : ControllerBase
{
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("issue")]
    public async Task<IActionResult> IssuePrescriptionAsync([FromBody] IssuePrescriptionDto dto, CancellationToken cancellationToken)
    {
        if(dto.DueDate < dto.Date)
        {
            return BadRequest("Due date cannot be in the past.");
        }
        
        if (dto.Medicaments.Count() > 10)
        {
            return BadRequest("Cannot issue more than 10 medicaments.");
        }
        
        var medicamentIds = dto.Medicaments.Select(x => x.IdMedicament).ToList();
        var medicamentsExists = await medicamentRepository.ExistsAsync(medicamentIds, cancellationToken);
        
        if(!medicamentsExists)
        {
            return NotFound("One or more medicaments do not exist.");
        }

        var prescription = new Prescription()
        {
            IdDoctor = dto.IdDoctor,
            Date = dto.Date,
            DueDate = dto.DueDate,
            PrescriptionMedicaments = dto.Medicaments.Select(x => new PrescriptionMedicament()
            {
                IdMedicament = x.IdMedicament,
                Dose = x.Dose,
                Details = x.Details
            }).ToList()
        };
        
        var patient = await patientRepository.GetAsync(dto.Patient.IdPatient, cancellationToken) ?? new Patient()
        {
            FirstName = dto.Patient.FirstName,
            LastName = dto.Patient.LastName,
            Birthdate = dto.Patient.Birthdate
        };

        prescription.Patient = patient;
        
        await prescriptionRepository.CreateAsync(prescription, cancellationToken);
        return Ok();
    }
    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("{idPatient}")]
    public async Task<IActionResult> GetPatientDataAsync([FromRoute] int idPatient, CancellationToken cancellationToken)
    {
        var patientExists = await patientRepository.ExistsAsync(idPatient, cancellationToken);
        
        if(!patientExists)
        {
            return NotFound("Patient does not exist.");
        }
        
        var patientData = await patientRepository.GetDataAsync(idPatient, cancellationToken);
        return Ok(new PatientDto(patientData));
    }
}