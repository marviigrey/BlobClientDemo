using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string conn_string = "<storage account key>";
        string containerName = "democontainer";
        BlobServiceClient blobServiceClient = new BlobServiceClient(conn_string);
        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        await containerClient.CreateIfNotExistsAsync();

        var metadata = new Dictionary<string, string>
        {
            {"user", "admin"},
            {"env", "lab"}
        };
        await containerClient.SetMetadataAsync(metadata);

        BlobContainerProperties properties = await containerClient.GetPropertiesAsync();
        foreach(var item in properties.Metadata)
        {
            Console.WriteLine($"{item.Key}:{item.Value }");
        }
    }
}