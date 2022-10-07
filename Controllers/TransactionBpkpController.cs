using Backend.Data;
using Backend.Data.Entities;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionBpkpController : Controller
    {
        private readonly ITransactionBpkbRepository _repo;
        public TransactionBpkpController(ITransactionBpkbRepository repo)
        {
            this._repo = repo;
        }

        // GET: api/[controller]
        [HttpGet]
        public ActionResult<IEnumerable<Transaction_bpkb>> GetValues()
        {
            try
            {
                var data = _repo.Get();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /*[HttpGet]
        [Route("get-transcation-by-id")]
        public async Task<IActionResult> GetTrBpkbByIdAsync(int id)
        {
            var cake = await _myWorldDbContext.transaction_bpkb.FindAsync(id);
            return Ok(cake);
        }*/

        [HttpPost]
        public async Task<IActionResult> Post(Transaction_bpkb transaction_Bpkb)
        {
            try
            {
                await _repo.Post(transaction_Bpkb);
                return Ok("ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }

        }
    }
}
