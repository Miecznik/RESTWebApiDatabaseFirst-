using RESTWebApiDatabaseFirst2.Models;

namespace RESTWebApiDatabaseFirst2.DTOs;

public class BedAssignmentsPostDTO
{
    public DateTime From { get; set; }
    public DateTime? To { get; set; }
    public BedType? BedType { get; set; }
    public string? Ward { get; set; }
}