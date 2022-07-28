using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStoreAPI.Data;
using GeneralStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private GeneralStoreDBContext _db;
        public TransactionController(GeneralStoreDBContext db)
        {
            _db = db;
        }
    [HttpPost]
        public async Task<IActionResult> CreateTransactions ([FromForm]TransactionEdit newTransaction)
        {
            Transaction transaction = new Transaction()
            {
                ProductId = newTransaction.ProductId,
                CustomerId = newTransaction.CustomerId,
                Quantity = newTransaction.Quantitiy,
            };
            _db.Transactions.Add(transaction);
            await _db.SaveChangesAsync();
            return Ok();
        }
    [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _db.Transactions.ToListAsync();
            return Ok();
        }
    [HttpPut]
    [Route("{id}")]
        public async Task<IActionResult> UpdateATransaction([FromForm] TransactionEdit model, [FromRoute] int id)
        {
            var oldTransaction = await _db.Transactions.FindAsync(id);
            if(oldTransaction == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(model.ProductId != null)
            {
                oldTransaction.ProductId = model.ProductId;
            }
            if(model.CustomerId != null)
            {
                oldTransaction.CustomerId = model.CustomerId;
            }
            if(model.Quantitiy != null)
            {
                oldTransaction.Quantity = model.Quantitiy;
            }
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}