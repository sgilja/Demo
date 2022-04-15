using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Persistence
{
    public interface IFileRepository : IGenericRepository<FolderFile, int>
    {
        Task<IEnumerable<string>> GetFiles(int? folderId, string fileName);
    }
}
