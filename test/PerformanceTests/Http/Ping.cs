// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace PerformanceTests
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Microsoft.Azure.WebJobs.Extensions.DurableTask;
    using System.Threading;

    /// <summary>
    /// A very simple Http Trigger that is useful for testing whether the orchestration service has started correctly, and what its
    /// basic configuration is.
    /// </summary>
    public static class Ping
    {
        [FunctionName(nameof(Ping))]
        public static Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [DurableClient] IDurableClient client,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var is64bit = Environment.Is64BitProcess;
            return Task.FromResult<IActionResult>(new OkObjectResult($"Hello from {client} ({(is64bit ? "x64":"x32")})\n"));
        }    
    }
}
