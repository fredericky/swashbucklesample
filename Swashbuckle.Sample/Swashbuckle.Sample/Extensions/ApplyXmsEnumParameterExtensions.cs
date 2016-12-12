using System.Globalization;
using System.Linq;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace Swashbuckle.Sample.Extensions
{
    /// <summary>
    /// Apply enum type for parameter of the operation.
    /// </summary>
    public class ApplyXmsEnumParameterExtensions : IOperationFilter
    {
        /// <summary>
        /// Apply enum property with the tag: x-ms-enum
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiDescription"></param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null) return;
            foreach (var parameter in operation.parameters.Where(x => x.@enum != null))
            {
                // ensure the first letter of enum class is uppercase.
                parameter.vendorExtensions.Add("x-ms-enum", new { name = ConvertFirstLetterToUppercase(parameter.name) });
            }
        }

        private static string ConvertFirstLetterToUppercase(string s)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s);
        }
    }
}