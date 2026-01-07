using Microsoft.EntityFrameworkCore;
using StoreService.Data;
using StoreService.DTOs;

namespace StoreService.Services
{
    public class ClientService : IClientService
    {
        private readonly StoreDbContext _db;

        public ClientService(StoreDbContext db)
        {
            _db = db;
        }

        public async Task<IReadOnlyList<BirthdayClientDto>> GetBirthdays(DateTime date)
        {
            return await _db.Clients
                .AsNoTracking()
                .Where(c => c.BirthDate.Month == date.Month && c.BirthDate.Day == date.Day)
                .Select(c => new BirthdayClientDto(c.Id, c.FullName))
                .ToListAsync();
        }

        public async Task<IReadOnlyList<RecentClientDto>> GetRecentClients(int days)
        {
            var fromDate = DateTime.UtcNow.AddDays(-days);

            return await _db.Purchases
                .AsNoTracking()
                .Where(p => p.Date >= fromDate)
                .GroupBy(p => p.Client)
                .Select(g => new RecentClientDto(
                    g.Key.Id,
                    g.Key.FullName,
                    g.Max(p => p.Date)
                ))
                .ToListAsync();
        }

        public async Task<IReadOnlyList<CategoryStatDto>> GetClientCategories(int clientId)
        {
            var clientExists = await _db.Clients
                .AsNoTracking()
                .AnyAsync(c => c.Id == clientId);
            if (!clientExists) return new List<CategoryStatDto>();

            return await _db.Purchases
                .AsNoTracking()
                .Where(p => p.ClientId == clientId)
                .SelectMany(p => p.Items)
                .AsNoTracking()
                .GroupBy(i => i.Product.Category.Name)
                .Select(g => new CategoryStatDto(
                    g.Key,
                    g.Sum(i => i.Quantity)
                ))
                .ToListAsync();
        }
    }
}