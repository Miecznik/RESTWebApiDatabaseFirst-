namespace RESTWebApiDatabaseFirst2.DTOs;

public class RoomDTO
{
    
    public string Id { get; set; } = null!;
    public bool HasTv { get; set; }

    public WardDto Ward { get; set; } = null!;

}