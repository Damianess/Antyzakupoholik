namespace Antyzakupoholik.Infrastructure;

public static class DependencyContainer
{
    private static readonly Dictionary<Type, object> Services = [];

    public static void Register<T>(T implementation)
    {
        Services[typeof(T)] = implementation!;
    }

    public static T Resolve<T>()
    {
        if (Services.TryGetValue(typeof(T), out var service))
        {
            return (T)service;
        }

        throw new Exception(
            $"Nie znaleziono serwisu: {typeof(T).Name}");
    }
}