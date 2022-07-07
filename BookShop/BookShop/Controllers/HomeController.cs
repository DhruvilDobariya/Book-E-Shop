using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public ActionResult<string> UploadFile(IFormFile file)
        {
            if(file == null)
            {
                return BadRequest("Please upload file");
            }
            string dirPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadFiles");

            string filePath = Path.Combine(dirPath, "1.png");
            var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);
            string dbPath = "UploadFile/" + "1.png";
            stream.Close();
            return Ok(filePath);
        }

        [HttpDelete]
        public ActionResult<string> DeleteFile(int id)
        {
            if(id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            string dirPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadFiles");

            string filePath = Path.Combine(dirPath, id + ".png");

            if (System.IO.File.Exists(filePath))
            {
                // If file found, delete it    
                System.IO.File.Delete(filePath);
                return Ok("File Deleted Successfully");
            }
            else return("File not found");
        } 
    }
}
