﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.Application.Workspace.Projects.Services;
using TaskoMask.Infrastructure.Data.DbContext;
using TaskoMask.Infrastructure.Data.EventSourcing;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Infrastructure.CrossCutting.Bus;
using TaskoMask.Domain.Core.Events;
using TaskoMask.Application.Common.Base.Queries.Models;
using TaskoMask.Application.Common.Base.Queries.Handlers;
using TaskoMask.Domain.Administration.Entities;
using TaskoMask.Application.Administration.Roles.Services;
using TaskoMask.Application.Administration.Operators.Services;
using TaskoMask.Application.Administration.Permissions.Services;
using TaskoMask.Application.Workspace.Members.Services;
using TaskoMask.Application.Workspace.Organizations.Services;
using TaskoMask.Application.Workspace.Boards.Services;
using TaskoMask.Application.Workspace.Cards.Services;
using TaskoMask.Application.Workspace.Tasks.Services;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Infrastructure.Data.Repositories;
using TaskoMask.Infrastructure.Data.Repositories.Workspace;
using TaskoMask.Infrastructure.Data.Repositories.Administration;
using TaskoMask.Domain.Administration.Data;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Infrastructure.CrossCutting.Services.Security;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Application.Common.Base.Commands.Handlers;
using TaskoMask.Application.Common.Base.Commands.Models;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.Workspace.Members.Entities;
using TaskoMask.Domain.Workspace.Organizations.Entities;
using TaskoMask.Domain.Workspace.Boards.Entities;
using TaskoMask.Domain.Workspace.Tasks.Entities;
using TaskoMask.Domain.Workspace.Members.Data;
using TaskoMask.Domain.Workspace.Organizations.Data;
using TaskoMask.Domain.Workspace.Boards.Data;
using TaskoMask.Domain.Workspace.Tasks.Data;

namespace Infrastructure.CrossCutting.IoC
{

    /// <summary>
    /// 
    /// </summary>
    public static class IoCConfig
    {


        /// <summary>
        /// 
        /// </summary>
        public static void ConfigureIocContainer(this IServiceCollection services)
        {
            #region Application

            services.AddScoped<IOperatorService, OperatorService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ITaskService, TaskService>();

            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();

            

            #endregion

            #region Infrastructure

            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.AddScoped<IEventStore, RedisEventStore>();
            services.AddScoped<IInMemoryBus, InMemoryBus>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IOperatorRepository, OperatorRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IInvitationRepository, InvitationRepository>();
            services.AddScoped<IEncryptionService, EncryptionService>();
            

            #endregion

            #region Generic Query Handlers

            //TODO Handel Generic Query Handlers

            services.AddScoped<IRequestHandler<GetCountQuery<Operator>, long>, BaseQueryHandlers<Operator>>();
            services.AddScoped<IRequestHandler<GetCountQuery<Member>, long>, BaseQueryHandlers<Member>>();
            services.AddScoped<IRequestHandler<GetCountQuery<Organization>, long>, BaseQueryHandlers<Organization>>();
            services.AddScoped<IRequestHandler<GetCountQuery<Project>, long>, BaseQueryHandlers<Project>>();
            services.AddScoped<IRequestHandler<GetCountQuery<Board>, long>, BaseQueryHandlers<Board>>();
            services.AddScoped<IRequestHandler<GetCountQuery<Task>, long>, BaseQueryHandlers<Task>>();
            services.AddScoped<IRequestHandler<GetCountQuery<Card>, long>, BaseQueryHandlers<Card>>();

            #endregion

            #region Generic Command Handlers

            //TODO Handel Generic Command Handlers

            services.AddScoped<IRequestHandler<DeleteCommand<Operator>, CommandResult>, BaseCommandHandlers<Operator>>();
            services.AddScoped<IRequestHandler<DeleteCommand<Permission>, CommandResult>, BaseCommandHandlers<Permission>>();
            services.AddScoped<IRequestHandler<DeleteCommand<Role>, CommandResult>, BaseCommandHandlers<Role>>();
           
            services.AddScoped<IRequestHandler<DeleteCommand<Invitation>, CommandResult>, BaseCommandHandlers<Invitation>>();
            services.AddScoped<IRequestHandler<DeleteCommand<Member>, CommandResult>, BaseCommandHandlers<Member>>();
            services.AddScoped<IRequestHandler<DeleteCommand<Organization>, CommandResult>, BaseCommandHandlers<Organization>>();
            services.AddScoped<IRequestHandler<DeleteCommand<Project>, CommandResult>, BaseCommandHandlers<Project>>();
            services.AddScoped<IRequestHandler<DeleteCommand<Board>, CommandResult>, BaseCommandHandlers<Board>>();
            services.AddScoped<IRequestHandler<DeleteCommand<Task>, CommandResult>, BaseCommandHandlers<Task>>();
            services.AddScoped<IRequestHandler<DeleteCommand<Card>, CommandResult>, BaseCommandHandlers<Card>>();

            #endregion
        }
    }
}
