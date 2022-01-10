using System;
using hw11.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace hw11.Infrastructure
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }

        public void HandleException<T>(T exception, LogLevel logLevel) where T : Exception
        {
            this.Handle((dynamic) exception, logLevel);
        }

        private void Handle(Exception exception, LogLevel logLevel)
        {
            _logger.Log(logLevel, exception, "Замечено исключение базового типа: {Message}", exception.Message);
        }

        private void Handle(NullReferenceException exception, LogLevel logLevel)
        {
            _logger.Log(logLevel, exception, "Замечен NullReferenceException: {Message}", exception.Message);
        }

        private void Handle(ArgumentException exception, LogLevel logLevel)
        {
            _logger.Log(logLevel, exception, "Замечен ArgumentException: {Message}", exception.Message);
        }
    }
}