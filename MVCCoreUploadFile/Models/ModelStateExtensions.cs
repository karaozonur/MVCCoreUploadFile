using Microsoft.AspNetCore.Mvc.ModelBinding;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVCCoreUploadFile.Models
{
    public static class ModelStateExtensions
    {
        //public static IEnumerable<Error> AllErrors(this ModelStateDictionary modelState)
        //{
        //    var result = from ms in modelState
        //                 where ms.Value.Errors.Any()
        //                 let fieldKey = ms.Key
        //                 let errors = ms.Value.Errors
        //                 from error in errors
        //                 select new Error(fieldKey, error.ErrorMessage);

        //    return result;
        //}
    }
}
