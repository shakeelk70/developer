namespace CodingTest.Domain;

public class CompanyContact : IEntity
{
    public int Id { get; init; }

    public int CompanyId { get; init; }

    public string? Title { get; set; }

    public string? GivenName { get; set; }

    public string? FamilyName { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }
}