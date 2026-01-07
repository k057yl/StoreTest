using StoreService.DTOs;

namespace StoreService.Services
{
    public interface IClientService
    {
        Task<IReadOnlyList<BirthdayClientDto>> GetBirthdays(DateTime date);
        Task<IReadOnlyList<RecentClientDto>> GetRecentClients(int days);
        Task<IReadOnlyList<CategoryStatDto>> GetClientCategories(int clientId);
    }
}
