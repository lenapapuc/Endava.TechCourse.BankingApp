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
            ArgumentNullException.ThrowIfNull(dbContext);
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

        public async Task<List<WalletDTO>> GetWallets()
        {
            var wallets = await _context.Wallets.Include(x => x.Currency).ToListAsync();
            var dtos = new List<WalletDTO>();
            foreach (var wallet in wallets)
            {
                var dto = new WalletDTO()
                {
                    Id = wallet.Id.ToString(),
                    Currency = wallet.Currency.Name,
                    Type = wallet.Type,
                    Amount = wallet.Amount,
                };

                dtos.Add(dto);
            }

            return dtos;
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
