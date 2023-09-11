using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectHemid.Data;
using ProjectHemid.Interface;
using ProjectHemid.Model.Domain;
using ProjectHemid.Model.Dto;
using ProjectHemid.Services;

namespace ProjectHemid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _repository;
        public PortfolioController(ApplicationdbContext repository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor)
        {
            _repository = new PortfolioService(repository, webHostEnvironment, contextAccessor);

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var domain = await _repository.GetByIdAsync(id);
            return Ok(new PortfolioDto { File = domain.File, FileTitle = domain.FileTitle, FileName = domain.FileName });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var domain = await _repository.DeleteAsync(Id);
            return Ok(new PortfolioDto { File = domain.File, FileName = domain.FileName, FileTitle = domain.FileTitle });
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] PortfolioDto dto)
        {

            ValidateFileUpload(dto);
            if (ModelState.IsValid)
            {
                var imageDomainModel = new Portfolio
                {
                    File = dto.File,
                    FileExtension = Path.GetExtension(dto.File.FileName).ToLower(),
                    FileName = dto.FileName,
                    FileSizeInBytes = dto.File.Length,
                    FileTitle = dto.FileTitle
                };
                await _repository.CreateAsync(imageDomainModel);
                return Ok(dto);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(PortfolioDto blogdto)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtensions.Contains(Path.GetExtension(blogdto.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }
            if (blogdto.File.Length > 3072000)
            {
                ModelState.AddModelError("file", "File size more than 3MB , please upload a smaller size file.");
            }
        }
    }
}
