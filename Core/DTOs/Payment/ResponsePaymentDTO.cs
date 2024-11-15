namespace Core.DTOs.Payment;

public class ResponsePaymentDTO
{
    public int PaymentId { get; set; }
    public int CardId { get; set; }
    public decimal AvailableCredit { get; set; }
    public DateTime Date { get; set; }
}
