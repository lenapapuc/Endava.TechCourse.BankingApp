using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Endava.TechCourse.BankApp.Shared;
using Endava.TechCourse.BankApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public WalletController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        [HttpPost]
        public IActionResult CreateWallet([FromBody] CreateWallteDTO createWallteDTO)
        {
            var wallet = new Wallet
            {
                Type = createWallteDTO.Type,
                Amount = createWallteDTO.Amount,
                Currency = new Currency
                {
                    Name = createWallteDTO.Currency.CurrencyName,
                    CurrencyCode = createWallteDTO.Currency.CurrencyCode,
                    ChangeRate = createWallteDTO.Currency.ChangeRate
                }
            };

            _context.Wallets.Add(wallet);
            _context.SaveChanges();

            return Ok();

        }
        [HttpGet]
        [Route("getWallets")]

        public async Task<List<Wallet>> GetWallets()
        {
                return await _context.Wallets
                    .Include(w=>w.Currency).ToListAsync();
            
        }

        [HttpGet("{id}")]
        public async Task<Wallet> GetWalletById(Guid id)
        {
            return await _context.Wallets
                 .Include(w => w.Currency) 
                 .FirstOrDefaultAsync(w => w.Id == id);
        }
        
      
    }
    
}
