using System;
using System.Linq;
using Swashbuckle.Swagger;

namespace Swashbuckle.Sample.Extensions
{
    /// <summary>
    /// Apply enum type for the definition.
    /// </summary>
    public class ApplyXmsEnumSchemaExtensions : ISchemaFilter
    {
        /// <summary>
        /// Apply enum property with the tag: x-ms-enum
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="type"></param>
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            foreach (var property in schema.properties.Where(x => x.Value.@enum != null))
            {
                property.Value.vendorExtensions.Add("x-ms-enum", new { name = property.Key });
            }
        }
    }
}