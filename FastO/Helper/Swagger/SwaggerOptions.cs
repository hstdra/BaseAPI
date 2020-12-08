using Microsoft.OpenApi.Models;

namespace FastO.Helper.Swagger
{
    public class SwaggerOptions : OpenApiInfo
    {
        public string VersionName { get; set; } = "v1";

        public string RoutePrefix { get; set; } = string.Empty;
    }
}
