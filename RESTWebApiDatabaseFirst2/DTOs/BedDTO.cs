namespace RESTWebApiDatabaseFirst2.DTOs;

public class BedDTO
{
    
   
        public int Id { get; set; }

        public BedTypeDTO BedType { get; set; } = null!;
        public RoomDTO Room { get; set; } = null!;
    

}