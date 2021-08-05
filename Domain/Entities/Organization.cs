﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Domain.Entities
{
    [Display(Name = nameof(DomainMetadata.Organization), ResourceType = typeof(DomainMetadata))]
    public class Organization : BaseEntity
    {
        public Organization(string name, string description, string userId)
        {
            Name = name;
            Description = description;
            UserId = userId;

            //example of using DomainException
            if (string.IsNullOrEmpty(UserId))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(userId)));

        }

        public string  Name { get; private set; }
        public string  Description { get; private set; }
        public string UserId { get; private set; }

      
        public void Update(string name, string description)
        {
            Description = description;
            Name = name;

        }
    }
}
