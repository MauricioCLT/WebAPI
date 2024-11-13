using Core.DTOs.Payment;

namespace Core.Interfaces.Repositories;

public interface IPaymentRepository
{
    Task<PaymentDTO> AddPaymentById(int id, CreatePaymentDTO createPaymentDTO);
}
