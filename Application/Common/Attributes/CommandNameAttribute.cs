using System;

namespace Application.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class CommandNameAttribute : Attribute
    {
        public readonly string CommandName;

        public CommandNameAttribute(string commandName)
        {
            this.CommandName = commandName;
        }
    }
}
