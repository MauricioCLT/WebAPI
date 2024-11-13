﻿namespace Core.DTOs.Charge;

public class CreateChargeDTO
{
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
