using Backend.Data;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Repository
{
    public class TransactionBpkbRepository : ITransactionBpkbRepository
    {
        private MyWorldDbContext _myWorldDbContext;
        public TransactionBpkbRepository(MyWorldDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }
        public async void Delete(string? agreement_number)
        {
            if (agreement_number == null)
            {
                throw new ArgumentNullException(nameof(agreement_number));
            }

            Transaction_bpkb data = _myWorldDbContext.transaction_bpkb.FirstOrDefault(s => s.agreement_number == agreement_number);

            if (data == null)
            {
                throw new ArgumentNullException(nameof(agreement_number));
            }

            _myWorldDbContext.transaction_bpkb.Remove(data);
            await _myWorldDbContext.SaveChangesAsync();
        }

        public ActionResult<IEnumerable<Transaction_bpkb>> Get()
        {
            var data = _myWorldDbContext.transaction_bpkb.ToList();
            return data;
        }

        public async Task Post(Transaction_bpkb transaction_bpkb)
        {
            try
            {
                if (transaction_bpkb == null)
                {
                    throw new ArgumentNullException(nameof(transaction_bpkb));
                }

                await _myWorldDbContext.transaction_bpkb.AddAsync(transaction_bpkb);
                await _myWorldDbContext.SaveChangesAsync();
            }
            catch (Exception ex) {
                throw new ArgumentNullException(nameof(ex));
            }
        }

        public async void Update(Transaction_bpkb transaction_bpkb)
        {
            if (transaction_bpkb == null)
            {
                throw new ArgumentNullException(nameof(transaction_bpkb));
            }

            Transaction_bpkb existingBpkb = _myWorldDbContext.transaction_bpkb.FirstOrDefault(s => s.agreement_number== transaction_bpkb.agreement_number);

            if (existingBpkb == null)
            {
                throw new ArgumentNullException(nameof(existingBpkb));
            }

            existingBpkb.agreement_number = transaction_bpkb.agreement_number;
            existingBpkb.bpkb_date = transaction_bpkb.bpkb_date;
            existingBpkb.bpkb_no = transaction_bpkb.bpkb_no;
            existingBpkb.bpkb_date_in = transaction_bpkb.bpkb_date_in;
            existingBpkb.faktur_date = transaction_bpkb.faktur_date;
            existingBpkb.faktur_no = transaction_bpkb.faktur_no;
            existingBpkb.branch_id = transaction_bpkb.branch_id;
            existingBpkb.location_id = transaction_bpkb.location_id;
            existingBpkb.police_no = transaction_bpkb.police_no;

            _myWorldDbContext.Attach(existingBpkb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _myWorldDbContext.SaveChangesAsync();
        }
    }
}
