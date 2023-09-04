using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Extensions
{
    public static class ModelStateExtension
    {
        public static List<String> GetErrors(this ModelStateDictionary modelState)
        {
            var result = new List<String>();
            foreach (var item in modelState.Values)
            {
                foreach (var error in item.Errors ) 
                { 
                    result.AddRange(item.Errors.Select(error => error.ErrorMessage));
                }
            }

            return result;
        }
    }
}
