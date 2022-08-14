﻿using TaskoMask.Services.Monolith.Application.Core.Commands;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Application.Share.Resources;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.Services.Monolith.Application.Workspace.Cards.Commands.Models
{

    public abstract class CardBaseCommand : BaseCommand
    {

        protected CardBaseCommand(string name , BoardCardType type)
        {
            Name = name;
            Type = type;
        }


        [Display(Name = nameof(ApplicationMetadata.Name), ResourceType = typeof(ApplicationMetadata))]
        [StringLength(DomainConstValues.Card_Name_Max_Length, MinimumLength = DomainConstValues.Card_Name_Min_Length, ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Name { get; }


        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public BoardCardType Type { get; }
    }
}
