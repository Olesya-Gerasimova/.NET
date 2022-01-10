using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace hw13.Services
{
    public class ExceptionHandler<TLogger>
    {
        private readonly ILogger<TLogger> _logger;

        public ExceptionHandler(ILogger<TLogger> logger)
        {
            _logger = logger;
        }

        public void HandleException<TException>(TException exception)
            where TException : Exception => this.Handle((dynamic)exception);

        private void Handle(Exception exception) =>
            _logger.LogError($"Exception: {exception.GetType().Name}");

        private void Handle(ArgumentException exception) =>
            _logger.LogError($"ArgumentException: {exception}");

        private void Handle(InvalidOperationException exception) =>
            _logger.LogError($"InvalidOperationException: {exception}");

        private void Handle(NotSupportedException exception) =>
            _logger.LogError($"NotSupportedException: {exception}");
    }
}