using Microsoft.AspNetCore.Mvc;
using WebAssessment.Data;

namespace WebAssessment.Controllers
{
    [ApiController]
    [Route("api/bankaccounts")]
    public class BankAccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BankAccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/bankaccounts
        [HttpPost]
        [ProducesResponseType(typeof(BankAccount), 201)] // 201 Created
        [ProducesResponseType(404)] // Not Found
        public IActionResult Post([FromBody] BankAccount bankAccount)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == bankAccount.UserId);

            if (user == null)
            {
                return NotFound("ID not found");
            }

            // Link the bank account to the user
            bankAccount.CurrentBalance = 0; // Initial balance is 0
            _context.BankAccounts.Add(bankAccount);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBankAccount), new { id = bankAccount.Id }, bankAccount);
        }

        // GET: api/bankaccounts/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BankAccount), 200)] // 200 OK
        [ProducesResponseType(404)] // Not Found
        public IActionResult GetBankAccount(int id)
        {
            var bankAccount = _context.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return NotFound("Bank account not found");
            }

            return Ok(bankAccount);
        }

        // POST: api/bankaccounts/deposit/{id}
        [HttpPost("deposit/{id}")]
        [ProducesResponseType(typeof(BankAccount), 200)] // 200 OK
        [ProducesResponseType(404)] // Not Found
        public IActionResult Deposit(int id, [FromBody] decimal depositAmount)
        {
            var bankAccount = _context.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return NotFound("Bank account not found");
            }

            if (depositAmount <= 0)
            {
                return BadRequest("Deposit amount must be greater than 0");
            }

            bankAccount.CurrentBalance += depositAmount;
            _context.SaveChanges();
            return Ok(bankAccount);
        }

        [HttpPost("withdraw/{id}")]
        [ProducesResponseType(typeof(BankAccount), 200)] // 200 OK
        [ProducesResponseType(404)] // Not Found
        public IActionResult Withdraw(int id, [FromBody] decimal withdrawalAmount)
        {
            var bankAccount = _context.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return NotFound("Bank account not found");
            }

            if (withdrawalAmount <= 0)
            {
                return BadRequest("Withdrawal amount must be greater than 0");
            }

            if (withdrawalAmount > bankAccount.CurrentBalance)
            {
                return BadRequest("Insufficient funds for withdrawal");
            }

            // Perform the withdrawal
            bankAccount.CurrentBalance -= withdrawalAmount;
            _context.SaveChanges();
            return Ok(bankAccount);
        }

    }

}
