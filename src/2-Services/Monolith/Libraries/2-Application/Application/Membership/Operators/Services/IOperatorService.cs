﻿using TaskoMask.Services.Monolith.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Membership.Operators;
using TaskoMask.Services.Monolith.Application.Share.ViewModels;
using System.Collections.Generic;
using TaskoMask.Services.Monolith.Application.Core.Services.Application;

namespace TaskoMask.Services.Monolith.Application.Membership.Operators.Services
{
    public interface IOperatorService: IApplicationService
    {
        Task<Result<CommandResult>> CreateAsync(OperatorUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(OperatorUpsertDto input);
        Task<Result<OperatorBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<OperatorBasicInfoDto>> GetByUserNameAsync(string userName);
        Task<Result<IEnumerable<OperatorOutputDto>>> GetListAsync();
        Task<Result<OperatorDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<CommandResult>> UpdateRolesAsync(string id, string[] rolesId);
        Task<Result<long>> CountAsync();
        Task<Result<CommandResult>> DeleteAsync(string id);
    }
}
