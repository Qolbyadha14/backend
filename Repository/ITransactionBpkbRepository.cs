using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Repository
{
    public interface ITransactionBpkbRepository
    {
        ActionResult<IEnumerable<Transaction_bpkb>> Get();

        Task Post(Transaction_bpkb transaction_bpkb);

        void Update(Transaction_bpkb transaction_bpkb);

        void Delete(string? id);
    }
}
