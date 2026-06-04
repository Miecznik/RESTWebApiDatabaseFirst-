using RESTWebApiDatabaseFirst2.DTOs;

namespace RESTWebApiDatabaseFirst2.Services;

public interface IDBService
{
    Task<IEnumerable<PatientsDTo>> GetPatients(string? search);
    Task<IEnumerable<BedAssignmentsPostDTO>> BedAssignments(string firstName, BedAssignmentsPostDTO dto);
}