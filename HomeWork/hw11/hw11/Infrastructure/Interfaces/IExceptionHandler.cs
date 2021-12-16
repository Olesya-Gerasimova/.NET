using System;
using Microsoft.Extensions.Logging;

namespace hw11.Infrastructure.Interfaces
{
    public interface IExceptionHandler
    {
        void HandleException<T>(T exception, LogLevel logLevel) where T : Exception;
    }
}