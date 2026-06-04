namespace RESTWebApiDatabaseFirst2.DTOs;

public class PatientsDTo
{
    public string Pesel { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public String Sex {get; set;}
    
    
    public List<AdmissionDTO> Admissions { get; set; } = new();
    public List<BedAssignmentDTO> BedAssignments { get; set; } = new();

}