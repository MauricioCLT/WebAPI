using Core.DTOs.Transactions;

namespace Core.Interfaces.Repositories;

public interface ITransactionsRepository
{
    Task<List<TransactionsDTO>> GetTransactions(int id);
}
