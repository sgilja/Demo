using Core.Interfaces.Persistence;

namespace Core.Entities
{
    public partial class FolderFile : IEntity<int>
    {
        public FolderFile()
        {
        }

        public int Id { get; set; }
        public int FolderId { get; set; }
        public string Name { get; set; }
        
        public virtual Folder Folder { get; set; }
    }
}
