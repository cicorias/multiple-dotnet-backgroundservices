namespace TestDualBackground
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddHostedService(provider => new Worker(1));
            builder.Services.AddHostedService(provider => new Worker(2));





            var host = builder.Build();
            host.Run();
        }
    }
}