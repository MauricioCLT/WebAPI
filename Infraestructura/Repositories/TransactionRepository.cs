using Core.DTOs.Payment;
using Core.DTOs.Transactions;
using Core.Interfaces.Repositories;
using Infraestructura.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories;

public class TransactionRepository : ITransactionsRepository
{
    private readonly AplicationDbContext _context;

    public TransactionRepository(AplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TransactionsDTO>> GetTransactions(int cardId, DateOnly startDate, DateOnly endDate)
    {
        var transaction = await _context.Cards
            .Include(p => p.Payments)
            .Include(c => c.Charges)
            .FirstOrDefaultAsync(i => i.CardId == cardId);

        var payments = transaction?.Payments.Select(p => new TransactionsDTO
        {
            Type = "Transaction",
            Amount = p.Amount,
            Date = p.Date,
            Description = "Pago Recibido"
        });

        var charges = transaction?.Charges.Select(c => new TransactionsDTO
        {
            Type = "Charge",
            Amount = c.Amount,
            Date = c.Date,
            Description = c.Description,
        });

        var startDateToEvalue = startDate.ToDateTime(TimeOnly.MinValue);
        var endDateToEvalue = endDate.ToDateTime(TimeOnly.MaxValue);

        return payments!.Concat(charges!)
                .OrderBy(r => r.Date)
                .Where(t => t.Date >= startDateToEvalue && t.Date <= endDateToEvalue)
                .ToList();
    }
}
