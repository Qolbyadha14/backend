using Backend.Data;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionBpkpController : Controller
    {
        private readonly MyWorldDbContext _myWorldDbContext;
        public TransactionBpkpController(MyWorldDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var data = await _myWorldDbContext.transaction_bpkb.ToListAsync();
            return Ok(data);
        }

        [HttpGet]
        [Route("get-transcation-by-id")]
        public async Task<IActionResult> GetTrBpkbByIdAsync(int id)
        {
            var cake = await _myWorldDbContext.transaction_bpkb.FindAsync(id);
            return Ok(cake);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Transaction_bpkb data)
        {
            _myWorldDbContext.transaction_bpkb.Add(data);
            await _myWorldDbContext.SaveChangesAsync();
            return Created($"/gget-transcation-by-id?id={data.agreement_number}", data);
        }

    }
}
