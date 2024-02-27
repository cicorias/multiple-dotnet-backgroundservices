namespace TestDualBackground
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            //builder.Services.AddHostedService(provider => new Worker(1));
            //builder.Services.AddHostedService(provider => new Worker(2));

            //builder.Services.AddHostedService<Worker>();
            //builder.Services.AddHostedService<Worker>();

            //builder.Services.AddKeyedSingleton<Worker>(1);
            //builder.Services.AddKeyedSingleton<Worker>(2);

            //var w = new Worker("0");

            // TODO: https://github.dev/cicorias/ordersimulator-distribution-based/tree/multiple
            builder.Services.AddSingleton<IHostedService, Worker>(provider =>
            {
                return new Worker("0", provider.GetRequiredService<ILogger<Worker>>());
            });

            builder.Services.AddSingleton<IHostedService, Worker>(provider =>
            {
                return new Worker("1", provider.GetRequiredService<ILogger<Worker>>());
            });

            //builder.Services.AddSingleton(provider => new Worker("1"));



            //builder.Services.AddHostedService<ScopedBackgroundService>();
            //builder.Services.AddScoped<IScopedProcessingService, DefaultScopedProcessingService>();


            var host = builder.Build();
            //w.Start();
            host.Run();
        }
    }
}