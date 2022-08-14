﻿using System.Collections.Generic;
using TaskoMask.Services.Monolith.Domain.Core.Exceptions;
using TaskoMask.Services.Monolith.Domain.Core.Models;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.ValueObjects.Owners
{
    /// <summary>
    /// 
    /// </summary>
    public class OwnerDisplayName : BaseValueObject
    {
        #region Properties

        public string Value { get; private set; }


        #endregion

        #region Ctors

        private OwnerDisplayName(string value)
        {
            Value = value;

            CheckPolicies();
        }

        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static OwnerDisplayName Create(string value)
        {
            return new OwnerDisplayName(value);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                throw new DomainException(string.Format(ContractsMetadata.Required, nameof(OwnerDisplayName)));
           
            if (Value.Length < DomainConstValues.Owner_DisplayName_Min_Length)
                throw new DomainException(string.Format(ContractsMetadata.Length_Error, nameof(OwnerDisplayName), DomainConstValues.Owner_DisplayName_Min_Length, DomainConstValues.Owner_DisplayName_Max_Length));

            if (Value.Length > DomainConstValues.Owner_DisplayName_Max_Length)
                throw new DomainException(string.Format(ContractsMetadata.Length_Error, nameof(OwnerDisplayName), DomainConstValues.Owner_DisplayName_Min_Length, DomainConstValues.Owner_DisplayName_Max_Length));

            //TODO should only contain alphabet and space ...
        }



        /// <summary>
        /// 
        /// </summary>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }


        #endregion

    }
}
