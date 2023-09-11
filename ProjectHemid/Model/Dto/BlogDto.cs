using System.ComponentModel.DataAnnotations;

namespace ProjectHemid.Model.Dto
{
    public class BlogDto
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }

        public string Title { get; set; }

        public string FileDescription { get; set; }
    }
}
