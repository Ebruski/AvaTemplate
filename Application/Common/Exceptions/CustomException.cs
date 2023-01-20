using System;

namespace Application.Common.Exceptions
{
    public class CustomException : Exception
    {
        public string Code { get; set; }
        public CustomException(string code = null)
            : base()
        {
            Code = code ?? "303";
        }

        public CustomException(string message, string code = null)
            : base(message)
        {
            Code = code ?? "303";
        }

        public CustomException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CustomException(string name, object key)
            : base($"Entity \"{name}\" ({key}) resulted into an error.")
        {
        }
    }
}
