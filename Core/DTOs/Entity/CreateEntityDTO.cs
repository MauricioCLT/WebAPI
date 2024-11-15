namespace Core.DTOs.Entity;

public class CreateEntityDTO
{
    public int CustomerId { get; set; }
    public string EntityName { get; set; } = string.Empty;
}
