﻿using TaskoMask.Services.Owners.Read.Api.Domain;
using Xunit;

namespace TaskoMask.Services.Owners.Read.Tests.Integration.Fixtures;

/// <summary>
///
/// </summary>
[CollectionDefinition(nameof(ProjectCollectionFixture))]
public class ProjectCollectionFixtureDefinition : ICollectionFixture<ProjectCollectionFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}

/// <summary>
///
/// </summary>
public class ProjectCollectionFixture : TestsBaseFixture
{
    public ProjectCollectionFixture()
        : base(dbNameSuffix: nameof(ProjectCollectionFixture)) { }

    /// <summary>
    ///
    /// </summary>
    public async Task SeedProjectAsync(Project project)
    {
        await _dbContext.Projects.InsertOneAsync(project);
    }
}
