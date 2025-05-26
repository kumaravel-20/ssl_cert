using System;
using System.Net.Http;
using System.Threading.Tasks;

public class App
{
    private readonly IHttpClientFactory _clientFactory;

    public App(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task Run()
    {
        var client = _clientFactory.CreateClient("MyClientWithCert");
        var response = await client.GetAsync("https://postman-echo.com/get");

        Console.WriteLine($"Status: {response.StatusCode}");
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Content: {content}");
    }
}
