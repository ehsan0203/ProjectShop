using ProjectHemid.Model.Domain;

namespace ProjectHemid.Interface
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllAsync();

        Task<Blog> GetByIdAsync(Guid id);

        Task<Blog> CreateAsync(Blog blog);


        Task<Blog> DeleteAsync(Guid Id);
    }
}
