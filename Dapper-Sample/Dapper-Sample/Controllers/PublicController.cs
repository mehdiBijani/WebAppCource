using Microsoft.AspNetCore.Mvc;

namespace Dapper_Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public PublicController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("upload-single")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadSingle([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("هیچ فایلی ارسال نشده");

            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "converted");
            Directory.CreateDirectory(folder);

            var tiffPath = Path.Combine(folder, $"{Path.GetFileNameWithoutExtension(file.FileName)}.tiff");

            using var image = System.Drawing.Image.FromStream(file.OpenReadStream());
            image.Save(tiffPath, System.Drawing.Imaging.ImageFormat.Tiff);

            return Ok(new { message = "فایل با موفقیت ذخیره شد", path = tiffPath });
        }
    }
}