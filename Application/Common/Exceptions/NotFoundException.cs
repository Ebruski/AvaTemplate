using System;

namespace Application.Common.Exceptions
{
    public class RefreshTokenAuthorizationException : Exception
    {
        public RefreshTokenAuthorizationException()
            : base()
        {
        }

        public RefreshTokenAuthorizationException(string message)
            : base(message)
        {
        }

        public RefreshTokenAuthorizationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public RefreshTokenAuthorizationException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
