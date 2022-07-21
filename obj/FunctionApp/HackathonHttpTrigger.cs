using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace My.Function
{
    public static class HackathonHttpTrigger
    { 
        private readonly IAlertService _alertService;

        public HackathonHttpTrigger(IAlertService alertService) {
            _alertService = alertService;
        }

        [FunctionName(nameof(CreateAlertMessage))]
        public static async Task<IActionResult> CreateAlertMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "https://tmoonetouch.azurewebsites.net/alerts/{deviceId}/{placement}/{timestamp}")] 
            HttpRequest req,
            int deviceId,
            string placement,
            DateTime timestamp,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject<RequestModel>(requestBody);
            var response = await _alertService.CreateAlert(deviceId , placement , timestamp);
            return new OkObjectResult(response);
        }

        [FunctionName(nameof(GetAlertMessages))]
        public static async Task<IActionResult> GetAlertMessages(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "https://tmoonetouch.azurewebsites.net/alerts")] 
            HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var response = await _alertService.GetAlertMessages();
            return new OkObjectResult(response);
        }
    
    }

}
