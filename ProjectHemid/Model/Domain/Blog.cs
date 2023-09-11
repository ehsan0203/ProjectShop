using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHemid.Model.Domain
{
    public class Blog
    {
        public Guid Id { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        public string FileName { get; set; }

        public string Title { get; set; }

        public string FileDescription { get; set; }


        public string FileExtension { get; set; }

        public long FileSizeInBytes { get; set; }

        public string FilePath { get; set; }


    }
}
