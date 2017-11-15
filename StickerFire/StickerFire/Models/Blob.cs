using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace StickerFire.Models
{
    public static class Blob
    {
        public static CloudBlobContainer ConnectToContainer(string id) //This is to DRY up connecting to the user container
        {
            CloudStorageAccount storageAccount = null;
            try
            {
                storageAccount = new CloudStorageAccount(
             new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
             "stickerfireblob",
             "35haxRA/RP4oE5X1QOt4A1neoNAqBFqgXWm0d41uBhPOL2QTS704DgusJsqBiJdC93xPcP90YeeHgKT09SwoRg=="), true);
            }
            catch (StorageException e)
            {
                Console.WriteLine();
            }
            // Create a blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Get a reference to a container named "<userid>conntainer"
            CloudBlobContainer container = blobClient.GetContainerReference($"{id}container");
            
            return container;
        }
        public static async Task MakeAContainer(string id)
        {
            var container = ConnectToContainer(id);

            // If "<userid>conntainer" doesn't exist, create it.
            await container.CreateIfNotExistsAsync();
        }

        public static void GetABlob(string id)
        {
            var container = ConnectToContainer(id);

            //await Blob.GetABlob(user.Id);

        }

        public static async Task UploadBlob(string id)
        {
            var container = ConnectToContainer(id);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("referenceName");
            // Create or overwrite the "myblob" blob with the contents of a local file
            // named "myfile".
            using (var fileStream = System.IO.File.OpenRead(@""))
            {
                await blockBlob.UploadFromStreamAsync(fileStream);
            }
        }
    }
}
