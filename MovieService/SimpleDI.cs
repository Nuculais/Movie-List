using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieService
{
    /// <summary>
    /// A simple Dependency Injection container.
    /// </summary>
    public static class SimpleDI
    {
        /// <summary>
        /// Name of the registered service.
        /// </summary>
        private static string serviceName;

        /// <summary>
        /// Constructor that registers a service from the configuration file.
        /// </summary>
        static SimpleDI()
        {
            RegisterService(MovieService.Configuration.IMovieService);
        }
        
        /// <summary>
        /// Register the name of the service
        /// </summary>
        /// <param name="name">name.</param>
        public static void RegisterService(string name)
        {            
            serviceName = name;
        }

        /// <summary>
        /// Gets an instance of the registered service.
        /// </summary>
        /// <returns></returns>
        public static IMovieService GetService()
        {
            if (serviceName == "InMemoryMovieService")
                return new InMemoryMovieService();
            if (serviceName == "CsvMovieService")
                return new CsvMovieService();

            throw new InvalidOperationException("No matching service!");
        }
    }
}
