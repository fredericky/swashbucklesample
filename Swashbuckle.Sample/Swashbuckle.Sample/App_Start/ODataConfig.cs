﻿using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Microsoft.OData.Edm;
using Swashbuckle.Sample.Models;

namespace Swashbuckle.Sample
{
    public static class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
            config.MapODataServiceRoute("ODataFunctionRoute", "odata", GetFunctionsEdmModel());;
            config.MapODataServiceRoute("ODataRoute", "odata", GetDefaultModel());
        }

        private static IEdmModel GetFunctionsEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EnableLowerCamelCase();
            builder.EntitySet<Student>("Students");
            //builder.EnumType<Gender>();

            // Function bounds to a collection that accepts an enum parameter.
            var studentType = builder.EntityType<Student>();
            var enumParamFunction = studentType.Collection.Function("GetByGender");
            enumParamFunction.Parameter<Gender>("gender");
            enumParamFunction.ReturnsCollectionFromEntitySet<Student>("Students");

            return builder.GetEdmModel();
        }

        private static IEdmModel GetDefaultModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EnableLowerCamelCase();
            builder.EntitySet<Student>("Students");
            //builder.EnumType<Gender>();
            return builder.GetEdmModel();
        }
    }
}
