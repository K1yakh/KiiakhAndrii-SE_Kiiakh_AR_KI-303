namespace lab3_12.api.Models;

public class PatientRoom
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int RoomId { get; set; }
    public DateTime AssignmentDate { get; set; }
    
    public virtual Patient Patient { get; set; }
    public virtual Room Room { get; set; }
}