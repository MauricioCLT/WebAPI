namespace Core.DTOs.Customer;

public class CreateCustomerDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime BirthDate { get; set; }
}
