using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repositories;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

        public readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository) 
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {
                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,
                };

                await imageRepository.Upload(imageDomainModel);
                return Ok(imageDomainModel);
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (allowedExtensions.Contains(Path.GetExtension(request.File.FileName)) == false ) 
            {
                ModelState.AddModelError("file", "Unsupportable file extension");
            }

            if(request.File.Length > 10485760)//10 mb
            {
                ModelState.AddModelError("file", "File size is more than 10MB, please upload a smaller size file.");
            }
        }
    }
}
