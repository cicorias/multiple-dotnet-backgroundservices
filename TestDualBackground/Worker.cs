namespace TestDualBackground
{
    public class Worker : BackgroundService
    {
        private readonly string _instanceId;
        private readonly ILogger<Worker> _logger;

        public Worker(string instanceId, ILogger<Worker> logger)
        {
            //_instanceId = Guid.NewGuid().ToString("D");
            _instanceId = instanceId;
            _logger = logger;
        }

        public void Start()
        {
            _logger.LogInformation("{id} started...", _instanceId);
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
