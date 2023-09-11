using System.ComponentModel.DataAnnotations;

namespace ProjectHemid.Model.Dto
{
    public class PortfolioDto
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }

        public string? FileTitle { get; set; }
    }
}
