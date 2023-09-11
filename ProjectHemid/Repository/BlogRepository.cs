using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHemid.Data;
using ProjectHemid.Model.Domain;


namespace ProjectHemid.Repository
{
    public class BlogRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IWebHostEnvironment webHostEnvironment;

        private ApplicationdbContext repository;



        public BlogRepository(ApplicationdbContext repository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor)
        {
            this.repository = repository;
            this.webHostEnvironment = webHostEnvironment;
            this.contextAccessor = contextAccessor;
        }

        [HttpGet("GetAll")]
        public async Task<List<Blog>> GetAll()
        {
               return  await repository.Blogs.ToListAsync();
        }

        [HttpGet("GetById")]
        public async Task<Blog> GetById(Guid Id)
        {
           
            var result= await repository.Blogs.FirstOrDefaultAsync(b => b.Id == Id);
            if(result == null)
            {
                return null;
            }
            return result;
        }

        [HttpPost("Create")]
        public async Task<Blog> Create(Blog blog)
        {

            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{blog.FileName}{blog.FileExtension}");
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await blog.File.CopyToAsync(stream);
            var urlFilePath = $"{contextAccessor.HttpContext.Request.Scheme}://{contextAccessor.HttpContext.Request.Host}{contextAccessor.HttpContext.Request.PathBase}/Images/{blog.FileName}{blog.FileExtension}";
            blog.FilePath = urlFilePath;
            await repository.Blogs.AddAsync(blog);
            await repository.SaveChangesAsync();
            return blog;


        }


        [HttpDelete("Delete")]
        public async Task<Blog> Delete(Guid Id)
        {
           var result= await repository.Blogs.FirstOrDefaultAsync(b => b.Id == Id);
            repository.Remove(result);
            await repository.SaveChangesAsync();
            return result;
        }

    }
}
