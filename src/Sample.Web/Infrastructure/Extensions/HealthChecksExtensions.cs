using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Microsoft.Extensions.DependencyInjection;

public static class HealthChecksExtensions
{
    private const string _startup = "startup";
    private const string _readiness = "readiness";
    private const string _liveness = "liveness";

    public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services)
    {
        return services
                .AddHealthChecks()
                .AddCheck(
                    "self",
                    () => HealthCheckResult.Healthy(),
                    tags: new[] { _liveness, _readiness, _startup })
                .Services;
    }

    public static IEndpointRouteBuilder RegisterHealthChecks(this IEndpointRouteBuilder e, string prefixHealthPath = "")
    {

        e.MapHealthChecks($"{prefixHealthPath}/health/{_startup}", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains(_startup)
        }).WithGroupName("HealthChecks");
        e.MapHealthChecks($"{prefixHealthPath}/health/{_liveness}", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains(_liveness)
        }).WithGroupName("HealthChecks");
        e.MapHealthChecks($"{prefixHealthPath}/health/{_readiness}", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains(_readiness)
        }).WithGroupName("HealthChecks");

        return e;
    }
}
