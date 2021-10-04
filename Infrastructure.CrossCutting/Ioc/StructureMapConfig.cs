﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;
using TaskoMask.Application.Team.Projects.Services;
using TaskoMask.Domain.Core.Data;

using TaskoMask.Infrastructure.Data.DbContext;
using TaskoMask.Infrastructure.Data.EventSourcing;

using MediatR.Pipeline;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Infrastructure.CrossCutting.Bus;
using TaskoMask.Domain.Core.Events;
using TaskoMask.Application.Common.BaseEntitiesUsers.Queries.Models;
using TaskoMask.Application.Common.BaseEntitiesUsers.Queries.Handlers;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Behaviors;
using TaskoMask.Application.Common.BaseEntities.Queries.Models;
using TaskoMask.Application.Common.BaseEntities.Queries.Handlers;
using StructureMap.Graph.Scanning;
using StructureMap.Graph;
using TaskoMask.Application.Core.Queries;
using System.Linq;
using TaskoMask.Domain.Core.Models;

namespace Infrastructure.CrossCutting.Ioc
{

    /// <summary>
    /// 
    /// </summary>
    public static class StructureMapConfig
    {


        /// <summary>
        /// 
        /// </summary>
        public static IServiceProvider ConfigureIocContainer(this IServiceCollection services, IConfiguration configuration)
        {
            var container = new Container();
            container.Configure(config =>
            {
                //Automatic resolve dependency by default conventions where we have SomeService : ISomeService
                config.Scan(s =>
                {
                    //scan application dll
                    s.AssemblyContainingType<IProjectService>();
                    //scan application.Core dll
                    s.AssemblyContainingType<IInMemoryBus>();
                    //scan Domain dll
                    s.AssemblyContainingType<IProjectRepository>();
                    //scan Domain.Core dll
                    s.AssemblyContainingType<IDomainEvent>();
                    //Scan Infrastructre.Data dll
                    s.AssemblyContainingType<IMongoDbContext>();
                    //Scan Infrastructure.CrossCutting dll
                    s.AssemblyContainingType<InMemoryBus>();
                    s.WithDefaultConventions().OnAddedPluginTypes(c => c.ContainerScoped());
                });

                config.For<IConfiguration>().Use(()=> configuration).Singleton();
                config.For<IEventStore>().Use<RedisEventStore>().ContainerScoped();
              
                #region Generic Query Handlers

                //TODO Handel Generic Command And Queries
                //  config.For(typeof(IRequestHandler<GetCountQuery<Operator>, long>)).Use(typeof(BaseQueryHandlers<Operator>)).ContainerScoped();

                services.AddScoped<IRequestHandler<GetCountQuery<Operator>, long>, BaseQueryHandlers<Operator>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Manager>, long>, BaseQueryHandlers<Manager>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Organization>, long>, BaseQueryHandlers<Organization>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Project>, long>, BaseQueryHandlers<Project>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Board>, long>, BaseQueryHandlers<Board>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Task>, long>, BaseQueryHandlers<Task>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Card>, long>, BaseQueryHandlers<Card>>();


                services.AddScoped<IRequestHandler<GetUserByIdQuery<Operator>, UserBasicInfoDto>, UserQueryHandlers<Operator>>();
                services.AddScoped<IRequestHandler<GetUserByIdQuery<Manager>, UserBasicInfoDto>, UserQueryHandlers<Manager>>();

                services.AddScoped<IRequestHandler<GetUserByPhoneNumberQuery<Operator>, UserBasicInfoDto>, UserQueryHandlers<Operator>>();
                services.AddScoped<IRequestHandler<GetUserByPhoneNumberQuery<Manager>, UserBasicInfoDto>, UserQueryHandlers<Manager>>();

                services.AddScoped<IRequestHandler<GetUserByUserNameQuery<Operator>, UserBasicInfoDto>, UserQueryHandlers<Operator>>();
                services.AddScoped<IRequestHandler<GetUserByUserNameQuery<Manager>, UserBasicInfoDto>, UserQueryHandlers<Manager>>();

                services.AddScoped<IRequestHandler<ValidateUserPasswordQuery<Operator>, bool>, UserQueryHandlers<Operator>>();
                services.AddScoped<IRequestHandler<ValidateUserPasswordQuery<Manager>, bool>, UserQueryHandlers<Manager>>();


                #endregion

            });


            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
        }
    }
}
