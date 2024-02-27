using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDualBackground
{
    public sealed class DefaultScopedProcessingService(
        ILogger<DefaultScopedProcessingService> logger) : IScopedProcessingService
    {
        private int _executionCount;

        public async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                ++_executionCount;

                logger.LogInformation(
                    "{ServiceName} working, execution count: {Count}",
                    nameof(DefaultScopedProcessingService),
                    _executionCount);

                await Task.Delay(10_000, stoppingToken);
            }
        }
    }
}
