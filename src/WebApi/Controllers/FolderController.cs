using Core.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("folder")]
    public class FolderController : ControllerBase
    {
        private readonly IFolderService _folderService;

        public FolderController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateFolder(FolderModel model)
        {
            var id = await _folderService.CreateFolder(model.ParentId, model.Name);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFolder(int id)
        {
            await _folderService.DeleteFolder(id);

            return Ok();
        }

        [HttpPost("file")]
        public async Task<IActionResult> CreateFile(FileModel model)
        {
            var id = await _folderService.CreateFile(model.FolderId, model.Name);

            return Ok(id);
        }

        [HttpDelete("file/{id}")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            await _folderService.DeleteFile(id);

            return Ok();
        }

        [HttpGet("file/search")]
        public IActionResult SearchFiles(int? id, string name)
        {
            var files = _folderService.GetFiles(id, name);

            return Ok(files);
        }
    }
}