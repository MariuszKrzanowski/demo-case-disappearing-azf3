using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MrMatrix.Demo.Azf3
{
    public static class Function
    {
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function,  "post", Route = null)]
            HttpRequestMessage req,
            CloudTable assignedTable, // This table is assigned via binding.
             ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request. RequestUri={req.RequestUri} Request content={req.Content?.ReadAsStringAsync().Result}");

            // Here is a logic which operates on specific CloudTable
            await Task.Yield();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent($"Assigned table name {assignedTable.Name}", Encoding.UTF8,
                    "application/json")
            };
        }

    }
}
