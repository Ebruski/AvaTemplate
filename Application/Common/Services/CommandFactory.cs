using Application.Common.Attributes;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace Application.Common.Services
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IReadOnlyDictionary<string, Type> Commands;

        public CommandFactory()
        {
            var dict = new Dictionary<string, Type>();

            var types = Assembly.GetExecutingAssembly()
               .GetTypes()
               .Where(p => typeof(IRequest<ResponseModel>).IsAssignableFrom(p));

            foreach (var type in types)
            {
                var attr = type.GetCustomAttribute<CommandNameAttribute>();

                if (attr != null)
                {
                    dict.Add(attr.CommandName, type);
                }
            }

            Commands = dict;
        }

        public IRequest<ResponseModel> Create(GenericRequest request)
        {
            if (request.Service is null) throw new CustomException("301");

            if (!Commands.TryGetValue(request.Service, out var commandType)) throw new CustomException("301");

            if (request.Data is null) return (IRequest<ResponseModel>)Activator.CreateInstance(commandType);

            var command = (IRequest<ResponseModel>)request.Data.RootElement
                .Deserialize(commandType, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return command;
        }
    }
}
