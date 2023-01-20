using System;

namespace Domain.Exceptions
{
    public class InvalidProductException : Exception
    {
        public InvalidProductException(string message)
            : base(message)
        {
        }
    }
}
