namespace EFCodeFirst.Dtos.Abstractions;

public class PersonDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public PersonDto() { }
    
    public PersonDto(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}