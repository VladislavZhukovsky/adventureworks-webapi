using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AdventureWorks.AzureStorageClient.Clients
{
    public class BlobClient
    {
        private readonly CloudBlobClient blobClient;

        public BlobClient(CloudStorageAccount storageAccount)
        {
            blobClient = storageAccount.CreateCloudBlobClient();
        }

        public Guid UploadFile(string containerName, string filename, byte[] fileContent)
        {
            var container = blobClient.GetContainerReference(containerName);
            var fileId = Guid.NewGuid();
            var blob = container.GetBlockBlobReference($"{fileId}_{filename}");
            blob.UploadFromByteArray(fileContent, 0, fileContent.Length);
            return fileId;
        }
    }
}
