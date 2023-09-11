using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectHemid.Data;
using ProjectHemid.Interface;
using ProjectHemid.Model.Domain;
using ProjectHemid.Model.Dto;
using ProjectHemid.Repository;
using ProjectHemid.Services;

namespace ProjectHemid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {


        private readonly IBlogService _repository;
        public BlogController(ApplicationdbContext repository, IWebHostEnvironment webHostEnvironment , IHttpContextAccessor contextAccessor)
        {
            _repository = new BlogService(repository, webHostEnvironment, contextAccessor);

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
          var result= await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
           var domain= await _repository.GetByIdAsync(id);
            return Ok(new BlogDto { File = domain.File, FileDescription = domain.FileDescription, FileName = domain.FileName, Title = domain.Title });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var domain =await _repository.DeleteAsync(Id);
            return Ok(new BlogDto { File=domain.File,FileDescription=domain.FileDescription,FileName=domain.FileName,Title=domain.Title});
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] BlogDto dto)
        {

            ValidateFileUpload(dto);
            if (ModelState.IsValid)
            {
                var imageDomainModel = new Blog
                {
                    File = dto.File,
                    FileExtension = Path.GetExtension(dto.File.FileName).ToLower(),
                    FileName = dto.FileName,
                    FileSizeInBytes = dto.File.Length,
                    
                    FileDescription = dto.FileDescription,
                    Title = dto.Title
                };
                await _repository.CreateAsync(imageDomainModel);
                return Ok(dto);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(BlogDto blogdto)
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
