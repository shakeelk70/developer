namespace CodingTest.Domain;

public class Claimant : IEntity
{
    public int Id { get; init; }

    public string? FamilyName { get; set; }
    public string? GivenName { get; set; }
    public string? MiddleName { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }

    public virtual Company? Company { get; set; }
}
