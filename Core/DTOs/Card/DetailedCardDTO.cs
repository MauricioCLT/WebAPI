﻿namespace Core.DTOs.Card;

public class DetailedCardDTO
{
    public int CustomerId { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public decimal CreditLimit { get; set; }
    public DateTime ExpirationDate { get; set; }
    public float InterestRate { get; set; }
    public decimal AvailableCredit { get; set; }
}
