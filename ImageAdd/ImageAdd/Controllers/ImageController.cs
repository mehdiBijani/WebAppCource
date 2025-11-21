using System.IO;
using System.Linq;
using System.Web.Mvc;
using ImageAdd.Models;
using ImageAdd.Service;

namespace ImageAdd.Controllers
{
    public class ImageController : Controller
    {
        private readonly ImageService _service = new ImageService();

        public ActionResult Index()
        {
            var images = _service.GetAllImages();
            return View(images);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ImageViewModel model)
        {
            if (ModelState.IsValid && model.File != null)
            {
                int id = _service.AddImage(model.Title);

                string path = Server.MapPath("~/img/images/" + id + ".jpg");
                model.File.SaveAs(path);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var image = _service.GetAllImages().FirstOrDefault(x => x.Id == id);
            return View(image);
        }

        [HttpPost]
        public ActionResult Edit(ImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateImage(model.Id, model.Title);

                if (model.File != null)
                {
                    string path = Server.MapPath("~/img/images/" + model.Id + ".jpg");
                    string directory = Server.MapPath("~/img/images");
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    model.File.SaveAs(path);
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }

}