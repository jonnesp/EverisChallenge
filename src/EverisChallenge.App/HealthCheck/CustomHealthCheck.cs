using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace EverisChallenge.App.HealthCheck
{
    public class CustomHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(@"https://api.adviceslip.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync("advice");

            if (response.IsSuccessStatusCode) return new HealthCheckResult(status: HealthStatus.Healthy, description: "Api está saudavel.");
                    
            return new HealthCheckResult(status: HealthStatus.Unhealthy, description: "API está doente");

            
        }
    }
}
