using MediatR;
using MedicationTracking.Models;

namespace MedicationTracking.Features.Patient;

/// <summary>
///
/// </summary>
public class GetAllPatientsCommand : IRequest<List<PatientDtoWithId>> { }
