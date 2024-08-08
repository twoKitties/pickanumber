namespace Game.Code.Services
{
    public class ServiceLocator
    {
        private static class ServiceImplementation<TService>
        {
            public static TService Instance;
        }
        
        public static void Register<TService>(TService service) where TService : IService
        {
            ServiceImplementation<TService>.Instance = service;
        }

        public static TService Get<TService>() where TService : IService
        {
            return ServiceImplementation<TService>.Instance;
        }
    }
}