﻿using TaskoMask.Services.Monolith.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.Services.Monolith.Presentation.Framework.Share.Services.Http;
using TaskoMask.Services.Monolith.Presentation.Framework.Share.ApiContracts;

namespace TaskoMask.Services.Monolith.Presentation.UI.UserPanel.Services.API
{
    public class AccountApiService : IAccountApiService
    {
        #region Fields

        private readonly IHttpClientService _httpClientService;

        #endregion

        #region Ctor


        public AccountApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserJwtTokenDto>> Login(UserLoginDto input)
        {
            var url = $"/account/login";
            return await _httpClientService.PostAsync<UserJwtTokenDto>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserJwtTokenDto>> Register(RegisterOwnerDto input)
        {
            var url = $"/account/register";
            return await _httpClientService.PostAsync<UserJwtTokenDto>(url, input);
        }


        #endregion

        #region Private Methods



        #endregion







    }
}
