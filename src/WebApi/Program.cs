using WebApi.Common.Extensions;

namespace WebApi;

public static class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine($"Starting up, time = {DateTime.UtcNow:s}");
            var builder = WebApplication.CreateBuilder(args);
            builder.RegisterSerilog();
            builder.ConfigureServices();
            builder.ConfigureApp();
        }
        catch (Exception ex)
        {
            string type = ex.GetType().Name;
            if (type.Equals("StopTheHostException", StringComparison.Ordinal))
            {
                throw;
            }

            Console.WriteLine($"Application start-up failed. Exception = '{ex.Message}'");
        }
        finally
        {
            Console.WriteLine($"Shutting down, time = {DateTime.UtcNow:s}");
        }
    }
}