namespace TestDualBackground
{
    public class Worker : BackgroundService
    {
        private readonly int _instanceId;

        public Worker(int instanceId)
        {
            _instanceId = instanceId;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine($"Worker {_instanceId} running at: {DateTimeOffset.Now}");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
