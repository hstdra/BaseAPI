using FastO.Core.CQRS.Commands;
using FastO.Core.CQRS.Queries;
using FastO.Infrastructure.CQRS.Commands;
using FastO.Infrastructure.CQRS.Queries;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace FastO.Infrastructure.CQRS
{
    public static class CQRSExtensions
    {
        public static void AddCQRS(this IServiceCollection services, params Type[] types)
        {
            var assemblies = types.Select(type => type.GetTypeInfo().Assembly);
            
            services.AddMediatR(assemblies.ToArray());
            services.AddScoped<IQueryBus, QueryBus>();
            services.AddScoped<ICommandBus, CommandBus>();
        }
    }
}
