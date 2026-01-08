namespace lab3_12.api.Models;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<PatientRoom> PatientRoom { get; set; }
}