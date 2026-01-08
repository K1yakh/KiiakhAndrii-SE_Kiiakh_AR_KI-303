namespace lab2_12.Entity;

public class Patient
{
    public Patient(string name)
    {
        Name = name;
    }
    public int Id { get; set; }

    public string Name { get; set; }
}