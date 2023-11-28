
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

string connectionString = "DefaultEndpointsProtocol=https;AccountName=az204azstorage;AccountKey=O/V4ZTKu5F7gIgfPDLSQ2vSprugD1L5ldQIcGYTzqkLInjSUUL40v2tNMseKlaYA96clPSG73v7J+ASt69DAQA==;EndpointSuffix=core.windows.net";
string containerName = "az204";

await AcquireLease();

async Task AcquireLease()
    {

    string blobName = "index.html";
    BlobClient blobClient = new BlobClient(connectionString,containerName, blobName);

    BlobLeaseClient blobLeaseClient = blobClient.GetBlobLeaseClient();
    TimeSpan leaseTime = new TimeSpan(0, 0, 1, 00);

    Response<BlobLease> response = await blobLeaseClient.AcquireAsync(leaseTime);


    Console.WriteLine("Lease id is {0}", response.Value.LeaseId);

    }




