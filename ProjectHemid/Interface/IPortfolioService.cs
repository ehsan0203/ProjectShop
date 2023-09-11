using ProjectHemid.Model.Domain;
using ProjectHemid.Model.Dto;

namespace ProjectHemid.Interface
{
    public interface IPortfolioService
    {
        Task<List<Portfolio>> GetAllAsync();

        Task<Portfolio> GetByIdAsync(Guid id);

        Task<Portfolio> CreateAsync(Portfolio portfolio);


        Task<Portfolio> DeleteAsync(Guid Id);
    }
}
