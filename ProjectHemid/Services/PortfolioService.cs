using ProjectHemid.Data;
using ProjectHemid.Interface;
using ProjectHemid.Model.Domain;
using ProjectHemid.Repository;

namespace ProjectHemid.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly PortfolioRepository _repository;


        public PortfolioService(ApplicationdbContext repository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor)
        {
            _repository = new PortfolioRepository(repository, webHostEnvironment, contextAccessor);

        }

        public Task<Portfolio> CreateAsync(Portfolio portfolio)
        {
            return _repository.Create(portfolio);
        }

        public Task<Portfolio> DeleteAsync(Guid Id)
        {
            return _repository.Delete(Id);
        }

        public Task<List<Portfolio>> GetAllAsync()
        {
            return _repository.GetAll();
        }

        public Task<Portfolio> GetByIdAsync(Guid id)
        {
            return _repository.GetById(id);
        }

    }
}
