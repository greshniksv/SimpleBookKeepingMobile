using SimpleBookKeepingMobile.Database.Interfaces;

namespace SimpleBookKeepingMobile.Extensions
{
    public static class AddRepositoriesExtension
    {
        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            // Get repositories
            Type mainType = typeof(IBaseRepository<>);
            List<Type> allTypesOfIRepository =
                (from x in AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(s => s.GetTypes())
                    where !x.IsAbstract && !x.IsInterface &&
                          x.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == mainType)
                    select x).ToList();

            // Register
            foreach (var type in allTypesOfIRepository)
            {
                List<Type> interfaceTypes = type.GetInterfaces().Where(x => !x.IsGenericType).ToList();
                foreach (var interfaceType in interfaceTypes)
                {
                    if (interfaceType.GetInterfaces().Any(y => y?.GetGenericTypeDefinition() == mainType))
                    {
                        serviceCollection.AddScoped(interfaceType, type);
                    }
                }
            }
        }
    }
}
