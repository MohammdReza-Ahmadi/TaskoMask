﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Projects.Commands.Models;
using TaskoMask.Services.Monolith.Application.Share.Resources;
using TaskoMask.Services.Monolith.Application.Core.Commands;
using TaskoMask.Services.Monolith.Application.Core.Notifications;
using TaskoMask.Services.Monolith.Application.Core.Exceptions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Monolith.Application.Core.Bus;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;
using TaskoMask.Services.Monolith.Domain.Core.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Projects.Commands.Handlers
{
    public class ProjectCommandHandlers : BaseCommandHandler,
        IRequestHandler<AddProjectCommand, CommandResult>,
         IRequestHandler<UpdateProjectCommand, CommandResult>,
         IRequestHandler<DeleteProjectCommand, CommandResult>
    {
        #region Fields

        private readonly IOwnerAggregateRepository _ownerAggregateRepository;


        #endregion

        #region Ctors

        public ProjectCommandHandlers(IOwnerAggregateRepository ownerAggregateRepository, IInMemoryBus inMemoryBus) : base(inMemoryBus)
        {
            _ownerAggregateRepository = ownerAggregateRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByOrganizationIdAsync(request.OrganizationId);
            if (owner == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            var project = Project.Create(request.Name, request.Description);
            owner.AddProject(request.OrganizationId, project);

            await _ownerAggregateRepository.UpdateAsync(owner);
            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ContractsMessages.Create_Success, project.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByProjectIdAsync(request.Id);
            if (owner == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            var loadedVersion = owner.Version;

            owner.UpdateProject(request.Id, request.Name, request.Description);

            await _ownerAggregateRepository.ConcurrencySafeUpdate(owner, loadedVersion);
            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ContractsMessages.Update_Success, request.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByProjectIdAsync(request.Id);
            if (owner == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            var loadedVersion = owner.Version;

            owner.DeleteProject(request.Id);

            await _ownerAggregateRepository.ConcurrencySafeUpdate(owner, loadedVersion);

            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ContractsMessages.Update_Success, request.Id);

        }



        #endregion

    }
}
