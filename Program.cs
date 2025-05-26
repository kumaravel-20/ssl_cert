using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static async Task Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddHttpClient("MyClientWithCert")
                    .ConfigurePrimaryHttpMessageHandler(() =>
                    {
                        var handler = new HttpClientHandler();

                        var cert = new X509Certificate2("..//..//shared//cert//testcert.pfx", "Test1234!");

                        handler.ClientCertificates.Add(cert);

                        return handler;
                    });

                services.AddTransient<App>();
            })
            .Build();

        await host.Services.GetRequiredService<App>().Run();
    }
}
