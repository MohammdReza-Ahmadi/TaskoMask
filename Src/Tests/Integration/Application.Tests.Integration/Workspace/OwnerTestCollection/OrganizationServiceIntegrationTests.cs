﻿using FluentAssertions;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Tests.Integration.TestData;
using TaskoMask.Application.Tests.Integration.TestData.Fixtures;
using TaskoMask.Application.Workspace.Organizations.Services;
using Xunit;


namespace TaskoMask.Application.Tests.Integration.Workspace.OwnerTestCollection
{
   
    [Collection(nameof(OwnerCollectionFixture))]
    public class OrganizationServiceIntegrationTests
    {
        #region Fields

        private readonly OwnerCollectionFixture _fixture;

        #endregion

        #region Ctor

        public OrganizationServiceIntegrationTests(OwnerCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Mthods


        [Fact]
        public async Task Organization_Is_Created_Properly()
        {
            //Arrange
            var dto = new OrganizationUpsertDto
            {
                Name = "Test Organization Name",
                Description = "Test Organization Description",
                OwnerId = "OwnerId",
            };

            //Act
            var result = await _fixture.OrganizationService.CreateAsync(dto);

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.EntityId.Should().NotBeNull();

        }





        #endregion

    }
}
