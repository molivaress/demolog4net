using log4netdemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage;
using Azure.Storage.Blobs;

namespace log4netdemo.Controllers
{
    public class FileController : Controller
    {

        private readonly IConfiguration _configuration;

        public FileController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost("upload")]
        public async Task<IActionResult> Upload(FileUploadModel model)
        {
            if (model.File == null || model.File.Length == 0)
                return BadRequest("No se proporcionó ningún archivo.");

            var connectionString = _configuration["AzureBlobStorage:ConnectionString"];
            var containerName = _configuration["AzureBlobStorage:ContainerName"];

            // Cliente del contenedor
            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // Asegúrate de que el contenedor exista
            await containerClient.CreateIfNotExistsAsync();

            // Sube el archivo
            var blobClient = containerClient.GetBlobClient(model.File.FileName);

            using (var stream = model.File.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, true);
            }

            return Ok($"Archivo subido correctamente: {blobClient.Uri}");
        }


    }
}
