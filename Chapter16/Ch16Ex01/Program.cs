using System;
using System.IO;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using static System.Console;

namespace Ch16Ex01
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                // creates the container
                //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;" +
                                    "AccountName=dafdevcards;" +
                                    "AccountKey=zvNYwPtqQXV7XqgclR8H3yjJz0S0SWVTJIgCzR9fBbMorDyJPAN5j7CovyD0iJvnm/2F+C+uVr3QxwHFumky4A==;" +
                                    "EndpointSuffix=core.windows.net");
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("carddeck");

                if (container.CreateIfNotExists())
                {
                    WriteLine($"Created container '{container.Name}' in storage account '{storageAccount.Credentials.AccountName}'.");
                }
                else
                {
                    WriteLine($"Container '{container.Name}' alreary exists for storage account '{storageAccount.Credentials.AccountName}'.");
                }

                container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                WriteLine($"Permission for container '{container.Name}' is public.");

                // uploads the card images
                int numberOfCards = 0;
                DirectoryInfo dir = new DirectoryInfo(@"Cards");
                foreach(FileInfo f in dir.GetFiles("*.*"))
                {
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(f.Name);
                    using(var fileStream = File.OpenRead(@"Cards/" + f.Name))
                    {
                        blockBlob.UploadFromStream(fileStream);
                        WriteLine($"Uploading: '{f.Name}' which is {fileStream.Length} bytes.");

                    }
                    numberOfCards++;
                }
                WriteLine($"Uploaded {numberOfCards.ToString()} cards.");
                WriteLine();


                // to check that all went well
                numberOfCards = 0;
                foreach(IListBlobItem item in container.ListBlobs(null, false))
                {
                    if(item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
                        WriteLine($"Card image url '{blob.Uri}' with length of {blob.Properties.Length}.");
                    }
                    numberOfCards++;
                }
                WriteLine($"Listed {numberOfCards.ToString()} cards.");

                // if desired, deletes the images
                WriteLine("Enter Y to delete listed cards, press enter to skip deletion:");
                if(ReadLine() == "Y")
                {
                    numberOfCards = 0;
                    foreach (IListBlobItem item in container.ListBlobs(null, false))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
                        CloudBlockBlob blockBlobToDelete = container.GetBlockBlobReference(blob.Name);
                        blockBlobToDelete.Delete();
                        WriteLine($"Deleted: '{blob.Name}' which was {blob.Properties.Length} bytes.");
                        numberOfCards++;
                    }
                    WriteLine($"Deleted {numberOfCards.ToString()} cards.");
                }
            }
            catch (StorageException ex)
            {
                WriteLine($"StorageException: {ex.Message}");
            }
            catch(Exception ex)
            {
                WriteLine($"Exception: {ex.Message}");
            }
            WriteLine("Press enter to exit.");
            ReadLine();
        }
    }
}
