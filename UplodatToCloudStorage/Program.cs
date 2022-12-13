// GOOGLE_APPLICATION_CREDENTIALS

using Google.Cloud.Storage.V1;

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS",
    @"C:\Users\mnadeem\OneDrive - Solenis LLC\GCP\CloudStorage\gcp-solenis-iot-prj-01-4aae08697e9f.json");

var storageClient = StorageClient.Create();
var path = @"C:\Users\mnadeem\OneDrive - Solenis LLC\GCP\CloudStorage\ToBeuploaded.txt";
using var f = File.OpenRead(path);
var filename=  Path.GetFileName(path);
storageClient.UploadObject("sol_cloud_storage_poc", $"incoming/{filename}", null, f);
Console.WriteLine($"uploaded {filename}");


//reading file
/*var options = new ListObjectsOptions {Delimiter = "/"};
foreach (var so in storageClient.ListObjects("sol_cloud_storage_poc", ""))
foreach (var so in storageClient.ListObjects("sol_cloud_storage_poc", "incoming/", options))
{
    if (so.Size > 0)
        Console.WriteLine(so.Name);
}*/