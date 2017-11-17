using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace StickerFire.Models
{
    //Enables Blob storage with Azure
    public static class Blob
    {
        public static CloudBlobContainer ConnectToContainer(string id) //This is to DRY up connecting to the user container
        {
            CloudStorageAccount storageAccount = null;
            try
            {
                storageAccount = new CloudStorageAccount(
             new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials("stickerfireblob", "/uQU92fEI5O3MetZ6Mc+Yvi4Y2g14RfFuIUib8a7p/3AxT1fTFA5S8/+QaWbZhtslQM+tOZMz2sF6udHXElACQ=="), true);
                
            }
            catch (StorageException e)
            {
                Console.WriteLine(e);
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

        public static async Task UploadBlob(string id, string title, string path)
        {
            var container = ConnectToContainer(id);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(title);
            await container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            // Create or overwrite the selected blob with the contents of a local file             
            using (var fileStream = System.IO.File.OpenRead(@path))
            {

                await blockBlob.UploadFromStreamAsync(fileStream);
            }
        }
        
        public static string GetBlobUrl(string id, string title)
        {
            var container = ConnectToContainer(id);
            var url = container.GetBlockBlobReference(title).StorageUri.PrimaryUri;
            return url.ToString();
        }
    }
}
