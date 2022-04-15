using Core.Interfaces.Persistence;

namespace Core.Entities
{
    public partial class Folder : IEntity<int>
    {
        public Folder()
        {
            Folders = new HashSet<Folder>();
            Files = new HashSet<FolderFile>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        
        public virtual Folder? Parent { get; set; }
        public virtual ICollection<Folder> Folders { get; set; }
        public virtual ICollection<FolderFile> Files { get; set; }
    }
}
