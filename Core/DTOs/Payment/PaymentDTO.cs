namespace Core.DTOs.Payment;

public class PaymentDTO
{
    public int PaymentId { get; set; }
    public int CardId { get; set; }
    public decimal Amount { get; set; }
    public string AvailableCredit { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
