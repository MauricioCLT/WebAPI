using Core.DTOs.Payment;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestructura.Contexts;
using Mapster;

namespace Infraestructura.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly AplicationDbContext _context;

    public PaymentRepository(AplicationDbContext context)
    {
        _context = context;        
    }

    public async Task<PaymentDTO> AddPaymentById(int id, CreatePaymentDTO createPaymentDTO)
    {
        var payment = await _context.Cards.FindAsync(id);
        if (payment == null)
            throw new Exception("No se encontró el Id de la tarjeta");

        var NewAvailableCredit = payment.CreditLimit >= (payment.AvailableCredit + createPaymentDTO.Amount)
            ? payment.AvailableCredit + createPaymentDTO.Amount 
            : throw new Exception($"El monto supera el limite de crédito. Le queda por pagar {payment.CreditLimit - payment.AvailableCredit}");

        var AddPayment = new Payment
        {
            CardId = id,
            Amount = createPaymentDTO.Amount,
            PaymentMethod = createPaymentDTO.PaymentMethod,
            Date = createPaymentDTO.Date
        };

        _context.Payments.Add(AddPayment);
        await _context.SaveChangesAsync();

        return AddPayment.Adapt<PaymentDTO>();
    }
}
