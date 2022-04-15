using Core.Entities;
using Core.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class FolderRepository : EfRepository<Folder, int>, IFolderRepository
    {
        public FolderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override void Delete(Folder entity)
        {
            RecursiveDelete(entity);

            base.Delete(entity);
        }

        private void RecursiveDelete(Folder parent)
        {
            var children = _context.Folders.Where(x => x.ParentId == parent.Id).ToList();

            foreach (var child in children) {
                RecursiveDelete(child);

                _context.Folders.Remove(child);
            }
        }
    }
}
