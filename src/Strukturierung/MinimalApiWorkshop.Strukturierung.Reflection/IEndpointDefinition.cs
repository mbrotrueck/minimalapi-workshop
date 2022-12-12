
namespace MinimalApiWorkshop.Strukturierung.Reflection;

public interface IEndpointDefinition
{
    void DefineServices(IServiceCollection services);

    void DefineEndpoints(WebApplication app);
}