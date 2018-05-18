namespace Foxkit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Container
    {
        private static IDictionary<Type, StoredObject> registerdServices =
            new Dictionary<Type, StoredObject>();

        public void Register<TService, TImplementation>()
            where TImplementation : class, TService
        {
            if (registerdServices.Any(x => x.Key is TService))
            {
                throw new Exception(typeof(TService).Name + " is already registerd");
            }

            var storedObject = new StoredObject
            {
                ContainerType = ContainerType.Class,
                Type = typeof(TImplementation)
            };

            #if NETSTANDARD1_1 || NETSTANDARD2_0
            var constructors = typeof(TImplementation).GetTypeInfo().DeclaredConstructors.ToList();
            var hasContructor = constructors.Count > 0;
            #else
            var constructors = typeof(TImplementation).GetConstructors(BindingFlags.CreateInstance);
            var hasContructor = constructors.Length > 0;
            #endif

            if (hasContructor)
            {
                var constructor = constructors[0];
                var parameters = constructor.GetParameters();

                storedObject.Parameters = parameters.ToList();
            }

            registerdServices.Add(typeof(TService), storedObject);
        }

        public void RegisterSingleton<TImplementation>(Func<TImplementation> getObjectFunc)
            where TImplementation : class
        {
            RegisterSingleton<TImplementation, TImplementation>(getObjectFunc);
        }

        public void RegisterSingleton<TService, TImplementation>(Func<TImplementation> getObjectFunc)
            where TImplementation : class
        {
            if (registerdServices.Any(x => x.Key is TService))
            {
                throw new Exception(typeof(TService).Name + " is already registerd");
            }

            var storedObject = new StoredObject
            {
                ContainerType = ContainerType.Class,
                Type = typeof(TImplementation),
                GetObject = getObjectFunc
            };

            #if NETSTANDARD1_1 || NETSTANDARD2_0
            var constructors = typeof(TImplementation).GetTypeInfo().DeclaredConstructors.ToList();
            var hasContructor = constructors.Count > 0;
            #else
            var constructors = typeof(TImplementation).GetConstructors(BindingFlags.CreateInstance);
            var hasContructor = constructors.Length > 0;
            #endif

            if (hasContructor)
            {
                var constructor = constructors[0];
                var parameters = constructor.GetParameters();

                storedObject.Parameters = parameters.ToList();
            }

            registerdServices.Add(typeof(TService), storedObject);
        }

        public bool ServiceExists(Type type)
        {
            return registerdServices.Any(x => x.Key == type);
        }

        public TService GetService<TService>()
            where TService : class
        {
            var type = typeof(TService);

            return GetService<TService>(type);
        }

        private TService GetService<TService>(Type type)
            where TService : class
        {
            return GetService(type) as TService;
        }

        private object GetService(Type type)
        {
            var typeExists = ServiceExists(type);

            if (!typeExists)
            {
                throw new Exception(type.Name + " don't exist or isn't registerd");
            }

            var storedObject = registerdServices[type];

            if (storedObject.CurrentContent.IsNullOrDefault())
            {
                if (storedObject.GetObject.IsNullOrDefault())
                {
                    if (!storedObject.Parameters.Any())
                    {
                        storedObject.CurrentContent = Activator.CreateInstance(storedObject.Type);

                        return storedObject.CurrentContent;
                    }

                    var parameters = new List<object>();

                    foreach (var parameter in storedObject.Parameters)
                    {
                        parameters.Add(GetService(parameter.ParameterType));
                    }

                    storedObject.CurrentContent = Activator.CreateInstance(storedObject.Type, parameters.ToArray());

                    return storedObject.CurrentContent;
                }

                storedObject.CurrentContent = storedObject.GetObject();

                return storedObject.CurrentContent;
            }

            return storedObject.CurrentContent;
        }
    }
}
