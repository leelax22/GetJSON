using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
// using Azure.Storage.Blobs;


namespace leelax.Function
{
    public static class GetJSONData
    {
        [FunctionName("GetJSONData")]
        public static String Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] 
            HttpRequest req, ILogger log, ExecutionContext context)
        

        {
            String connStrA = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            String requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            String valueA = data.a;
            
            // BlobServiceClient clientA = new BlobServiceClient(connStrA);


            return valueA;
        }
    }
}
