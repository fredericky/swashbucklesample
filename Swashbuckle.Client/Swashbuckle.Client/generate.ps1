$swaggerUrl = "http://localhost:8080/swagger/docs/v1"
$swaggerOutput = ".\swagger.json"
Invoke-WebRequest -Uri $swaggerUrl -OutFile $swaggerOutput

$generateFolder = "generated"
autoRest -Modeler Swagger -CodeGenerator CSharp -ClientName SwashbuckleSampleClient -Namespace Swashbuckle.Sample.Client -Input $swaggerOutput -outputDirectory $generateFolder