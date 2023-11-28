
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

string connectionString = "DefaultEndpointsProtocol=https;AccountName=azstorageacc204;AccountKey=JyP4QhuFK46C3gFx2Gu4tzeck/Gd7qG+FEuc88iU3RAb8kcIseaVC2Oy4SfOchAK9mbdvW0IMif++AStNWRIKw==;EndpointSuffix=core.windows.net";
string containerName = "sample";

await SetBlobMetaData();
await GetMetaData();
async Task SetBlobMetaData()
    {

    string blobName = "sample.txt";
    BlobClient blobClient = new BlobClient(connectionString,containerName, blobName);
    
    IDictionary<string,string> metaData =new Dictionary<string,string>();
    metaData.Add("Department", "Logistics");
    metaData.Add("Application", "AppA");

    await blobClient.SetMetadataAsync(metaData);

    Console.WriteLine("Metadata added");
    }

async Task GetMetaData()
{
    string blobName = "sample.txt";
    BlobClient blobClient = new BlobClient(connectionString, containerName, blobName);
    BlobProperties blobProperties = await blobClient.GetPropertiesAsync();

    foreach(var metaData in blobProperties.Metadata)
    {
        Console.WriteLine("The key is {0}", metaData.Key);
        Console.WriteLine("The value is {0}", metaData.Value);
    }

}


