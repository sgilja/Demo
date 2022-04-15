using Core.Entities;
using Core.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class FileRepository : EfRepository<FolderFile, int>, IFileRepository
    {
        public FileRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<string>> GetFiles(int? folderId, string fileName)
        {
            var files = await _context.Files
               .Where(f => folderId == null || f.FolderId == folderId)
               .Where(f => f.Name.ToLower().StartsWith(fileName.ToLower()))
               .OrderBy(f => f.Name)
               .Select(f => f.Name)
               .Take(10)
               .ToListAsync();

            return files;
        }
    }
}
