namespace Core.Common.Interfaces
{
    public interface IFolderService
    {
        Task<int> CreateFolder(int? parentId, string name);
        Task DeleteFolder(int id);
        Task<int> CreateFile(int folderId, string name);
        Task DeleteFile(int id);
        IEnumerable<string> GetFiles(int? folderId, string fileName);
    }
}
