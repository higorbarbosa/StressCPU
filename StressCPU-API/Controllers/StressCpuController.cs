using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace StressCPU.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StressCpuController : ControllerBase
    {
        [HttpGet, Route("API/CPU")]
        public IActionResult StressCPU(int seconds, int percentage)
        {
            int percentualCPU = Math.Max(100, percentage);
            var fimProcesso = DateTime.Now.AddSeconds(seconds);
            var perc = percentualCPU;
            Stopwatch watch = new();
            watch.Start();
            while (DateTime.Now < fimProcesso)
            {
                if (watch.ElapsedMilliseconds > perc)
                {
                    Thread.Sleep(100 - perc);
                    watch.Reset();
                    watch.Start();
                }
            }
            
            return Ok($"Used {percentage}% of CPU per {seconds} seconds");
        }
    }
}