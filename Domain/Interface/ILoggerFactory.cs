
using System;
using Microsoft.Extensions.Logging;

namespace myApi.Domain.Interface
{
    public interface ILoggerFactory : IDisposable
    {
        ILogger CreateLogger(string categoryName);
        void AddProvider(ILoggerProvider provider);
    }
}
