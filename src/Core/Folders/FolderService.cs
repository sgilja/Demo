using Core.Common.Interfaces;
using Core.Entities;
using Core.Folders;
using Core.Interfaces.Persistence;

namespace Core.Services
{
    public class FolderService : IFolderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFolderRepository _folderRepository;
        private readonly IFileRepository _fileRepository;

        public FolderService(IUnitOfWork unitOfWork, IFolderRepository folderRepository, IFileRepository fileRepository)
        {
            _unitOfWork = unitOfWork;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
        }

        public async Task<int> CreateFolder(int? parentId, string name)
        {
            if (name == null) {
                throw new ArgumentNullException(nameof(name));
            }

            var folder = new Folder() {
                ParentId = parentId,
                Name = name
            };

            _folderRepository.Add(folder);

            await _unitOfWork.CompleteAsync();

            return folder.Id;
        }

        public async Task DeleteFolder(int id)
        {
            var folder = _folderRepository.GetById(id);

            _folderRepository.Delete(folder);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<int> CreateFile(int folderId, string name)
        {
            if (name == null) {
                throw new ArgumentNullException(nameof(name));
            }

            var file = new FolderFile() {
                FolderId = folderId,
                Name = name
            };

            _fileRepository.Add(file);

            await _unitOfWork.CompleteAsync();

            return file.Id;
        }

        public async Task DeleteFile(int id)
        {
            var file = _fileRepository.GetById(id);

            _fileRepository.Delete(file);

            await _unitOfWork.CompleteAsync();
        }

        public IEnumerable<string> GetFiles(int? folderId, string fileName)
        {
            if (fileName == null) {
                throw new ArgumentNullException(nameof(fileName));
            }

            var files = _fileRepository.Search(new FileSearchSpecification(folderId, fileName));

            var fileNames = files.Select(f => f.Name);

            return fileNames;
        }
    }
}