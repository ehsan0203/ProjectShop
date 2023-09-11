using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHemid.Data;
using ProjectHemid.Model.Domain;

namespace ProjectHemid.Repository
{
    public class PortfolioRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IWebHostEnvironment webHostEnvironment;

        private ApplicationdbContext repository;



        public PortfolioRepository(ApplicationdbContext repository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor)
        {
            this.repository = repository;
            this.webHostEnvironment = webHostEnvironment;
            this.contextAccessor = contextAccessor;
        }

        [HttpGet("GetAll")]
        public async Task<List<Portfolio>> GetAll()
        {
            return await repository.Portfolios.ToListAsync();
        }

        [HttpGet("GetById")]
        public async Task<Portfolio> GetById(Guid Id)
        {
            return await repository.Portfolios.FirstOrDefaultAsync(b => b.Id == Id);
        }

        [HttpPost("Create")]
        public async Task<Portfolio> Create(Portfolio portfolio)
        {
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images",$"{portfolio.FileName}{portfolio.FileExtension}" );
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await portfolio.File.CopyToAsync(stream);
            var urlFilePath = $"{contextAccessor.HttpContext.Request.Scheme}://{contextAccessor.HttpContext.Request.Host}{contextAccessor.HttpContext.Request.PathBase}/Images/{portfolio.FileName}{portfolio.FileExtension}";
            portfolio.FilePath = urlFilePath;
            await repository.Portfolios.AddAsync(portfolio);
            await repository.SaveChangesAsync();
            return portfolio;
        }



        [HttpDelete("Delete")]
        public async Task<Portfolio> Delete(Guid Id)
        {
            var result = await repository.Portfolios.FirstOrDefaultAsync(b => b.Id == Id);
            repository.Remove(result);
            await repository.SaveChangesAsync();
            return result;
        }
    }
}
