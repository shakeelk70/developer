namespace CodingTest.Domain;

public interface IEntity
{
    public int Id { get; init; }
}

public class Company : IEntity
{
    public int Id { get; init; }

    public string? LegalName { get; set; }
    public string? TradingName { get; set; }
    public string? ABN { get; set; }
    public string? ACN { get; set; }

    public virtual ICollection<CompanyContact> CompanyContacts { get; init; }

    public Company() => CompanyContacts = new List<CompanyContact>();
}
