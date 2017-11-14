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
        public static async Task CallBlob(string id)
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
                // TODO handle later
            }
            // Create a blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Get a reference to a container named "mycontainer."
            CloudBlobContainer container = blobClient.GetContainerReference($"{id}container");

            // If "mycontainer" doesn't exist, create it.
            await container.CreateIfNotExistsAsync();
        }
                    //await Blob.CallBlob(user.Id);  this is how to call blob storage

    }
}
