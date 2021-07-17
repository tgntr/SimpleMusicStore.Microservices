using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleMusicStore.Contracts;
using SimpleMusicStore.ModelValidations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SimpleMusicStore.Api.Controllers
{
    public class PreviewController : Controller
    {
        private readonly FileStorage _cloud;

        public PreviewController(FileStorage cloud) : base()
        {
            _cloud = cloud;
        }
        [HttpPost]
        public Task Upload(string fileName, [Required, NonEmptyMp3File]IFormFile file)
        {
            return _cloud.Upload(file, fileName);
        }
    }
}