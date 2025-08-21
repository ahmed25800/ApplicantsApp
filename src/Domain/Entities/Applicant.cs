namespace Domain.Entities;

public class Applicant : BaseEntity
{
    // Empty constructor for EF Core
    private Applicant() { }

    // Main constructor for creating a new Applicant
    public Applicant(string name, string familyName, string address, string countryOfOrigin, string emailAdress, int age, bool hired = false)
    {
        Name = name;
        FamilyName = familyName;
        Address = address;
        CountryOfOrigin = countryOfOrigin;
        EmailAdress = emailAdress;
        Age = age;
        Hired = hired;
    }

    // Properties use private setters to enforce encapsulation
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string FamilyName { get; private set; }
    public string Address { get; private set; }
    public string CountryOfOrigin { get; private set; }
    public string EmailAdress { get; private set; }
    public int Age { get; private set; }
    public bool Hired { get; private set; }
    
    // Controlled update method instead of exposing public setters
    public void Update(string name, string familyName, string address, string countryOfOrigin, string emailAdress, int age, bool hired)
    {
        Name = name;
        FamilyName = familyName;
        Address = address;
        CountryOfOrigin = countryOfOrigin;
        EmailAdress = emailAdress;
        Age = age;
        Hired = hired;
    }
}
