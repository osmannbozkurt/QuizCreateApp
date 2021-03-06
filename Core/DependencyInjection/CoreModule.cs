
using Core.Logger;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyInjection
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        { 
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
            serviceCollection.AddSingleton<ILogger, FileLogger>(); 
        }
    }
}
