using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentsApiAzureFunction.Dal;
using StudentsApiAzureFunction.Service;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IStudentRepo, StudentRepo>();
        services.AddTransient<IStudentService, StudentService>();
    })
    .Build();

host.Run();
