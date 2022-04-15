using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class FolderModel
    {
        public int? ParentId { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class FileModel
    {
        [Required]
        public int FolderId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
