using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace MVCCoreUploadFile.Models
{
    //Her Seferinde tek dosya yüklemek için bu model kullanılacak.
    //Bu model, dosyayı sunucuda depolarken dosya adı olarak kullanacağımız FileName olmak üzere iki özellik içerir.
    //Diğeri ise, IFormFile türü olan File'dır.
    //Her iki özellik de, doğrulamayı kullanıcıya göstermek için Attributes  Özniteliklerine sahiptir.
    public class SingleFileModel: ResponseModel
    {
        [Required(ErrorMessage ="Lütfen Dosya Yükleyiniz")]
        public string FileName { get; set; } //

        [Required(ErrorMessage = "Lütfen Dosya Seçiniz")]
        public IFormFile File { get; set; } //IFormFile

        //List<string> isimler { get; set; }
    }
}
