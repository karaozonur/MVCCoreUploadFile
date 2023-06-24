using Microsoft.AspNetCore.Mvc;
using MVCCoreUploadFile.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace MVCCoreUploadFile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(SingleFileModel model)
        {
             //= new SingleFileModel();
            
            return View(model);
        }
        public IActionResult MultiFile(MultipleFilesModel model)
        {
            //= new SingleFileModel();

            return View(model);
        }


        
        //SingleFileModel - Tek Dosya Yükleme
        //SingleFileModel'i parametre olarak kabul eden Upload adında bir post metodu oluşturuyoruz.
        // ModelState.Valid özelliğini kullanarak modelimizin geçerli olup olmadığını kontrol ediyoruz.
        // Geçerliyse bir sonraki işleme gider, aksi takdirde hata mesajını gösterir.
        // dosyalarımızı depolayacağımız kök dizin yolumuzu içeren path adında bir değişken yaratıyoruz. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upload(SingleFileModel model)
        {
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            //if (ModelState.IsValid)
            //{
                model.IsResponse = true;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

                //Files oluştur
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //Dosya uzantısına bi bakalım
                FileInfo fileInfo = new FileInfo(model.File.FileName);
           
                string fileName=SeoHelper.ToSeoUrl(model.FileName) + fileInfo.Extension;

                var randomName = ($"{Guid.NewGuid()}{fileName}");

                string fileNameWithPath=Path.Combine(path, randomName);

           

            using (var stream =new FileStream(fileNameWithPath,FileMode.Create))
                {
                    model.File.CopyTo(stream);
                }
 

            model.IsSuccess= true;
                model.message = "Başarılı";


            //}
            return View("Index",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MultiUpload(MultipleFilesModel model)
        {
            //if (ModelState.IsValid)
            //{
                model.IsResponse = true;
                if (model.Files.Count>0)
                {
                    foreach (var item in model.Files)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string fileNameWithPath = Path.Combine(path, item.FileName);
                        using (var stream=new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            item.CopyTo(stream);

                        }
                    }
                    model.IsSuccess=true;
                    model.message = "Başarı";
                }
            //}
            //else
            //{
            //    model.IsSuccess = false;
            //    model.message = "Başarısız";
            //}
            return View("MultiFile",model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

    
    }
}