﻿using AutoMapper;
using TaskoMask.Application.Projects.Commands.Models;
using TaskoMask.Application.Core.Dtos.Projects;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Project, ProjectBasicInfoDto>();
            CreateMap<Project, ProjectInputDto>();
            CreateMap<ProjectBasicInfoDto, ProjectInputDto>();
        }
    }
}
