using Core.DTOs.Charge;
using Core.DTOs.Payment;

namespace Core.Interfaces.Services;

public interface ICardServices
{
    Task<ChargeDTO> CreateCharge(CreateChargeDTO request);
    Task<PaymentDTO> CreatePayment(CreatePaymentDTO request);
}
