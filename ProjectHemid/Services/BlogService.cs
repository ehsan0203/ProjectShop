using ProjectHemid.Data;
using ProjectHemid.Interface;
using ProjectHemid.Model.Domain;
using ProjectHemid.Repository;

namespace ProjectHemid.Services
{
    public class BlogService : IBlogService
    {


        private readonly BlogRepository _repository;


        public BlogService(ApplicationdbContext repository , IWebHostEnvironment webHostEnvironment , IHttpContextAccessor contextAccessor)
        {
            _repository = new BlogRepository(repository,webHostEnvironment,contextAccessor);
           
        }

        public Task<Blog> CreateAsync(Blog blog)
        {

            return _repository.Create(blog);
        }

        public Task<Blog> DeleteAsync(Guid Id)
        {
            return _repository.Delete(Id);
        }

        public Task<List<Blog>> GetAllAsync()
        {
            return _repository.GetAll();
        }

        public Task<Blog> GetByIdAsync(Guid id)
        {
            return _repository.GetById(id);
        }


    }
}
