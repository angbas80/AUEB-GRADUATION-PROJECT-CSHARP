using System.Runtime.CompilerServices;
using WebApplication1.DTO;

namespace WebApplication1.Validator
{
    public static class ProductValidator
    {
        public static string Validate(ProductDto dTo)
        {
            return (dTo.Name!.Length == 0) || (dTo.Description!.Length == 0) ? "Product's Name or Description can not be empty" : "";
        }
    }
}
