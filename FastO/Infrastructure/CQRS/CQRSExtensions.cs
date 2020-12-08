using FastO.Core.CQRS.Commands;
using FastO.Core.CQRS.Queries;
using FastO.Infrastructure.CQRS.Commands;
using FastO.Infrastructure.CQRS.Queries;
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
            services.AddMediatR(types.Select(type => type.GetTypeInfo().Assembly).ToArray());

            services.AddScoped<IQueryBus, QueryBus>();
            services.AddScoped<ICommandBus, CommandBus>();
        }
    }
}
