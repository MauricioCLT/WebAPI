using Core.DTOs.Payment;
using Core.Interfaces.Repositories;

namespace Infraestructura.Repositories;

public class TransactionRepository : IPaymentRepository
{
    public Task<PaymentDTO> AddPaymentById(int id, CreatePaymentDTO createPaymentDTO)
    {
        throw new NotImplementedException();
    }
}
