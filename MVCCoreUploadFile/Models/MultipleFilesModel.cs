using System.ComponentModel.DataAnnotations;

namespace MVCCoreUploadFile.Models
{
    public class MultipleFilesModel: ResponseModel
    {
        // aynı anda birden fazla dosya depolamak için kullanacağız.
        //Bu model, IFormFile listesinin türü olan yalnızca bir özellik içerir.

        [Required(ErrorMessage = "Lütfen Dosya Seçiniz")]
        public List<IFormFile> Files { get; set; }  
    }
}
