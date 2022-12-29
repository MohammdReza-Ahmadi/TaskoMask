﻿
using Xunit;

namespace TaskoMask.Services.Boards.Write.IntegrationTests.Fixtures
{


    /// <summary>
    /// 
    /// </summary>
    [CollectionDefinition(nameof(CardCollectionFixture))]
    public class CardCollectionFixtureDefinition : ICollectionFixture<CardCollectionFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }



    /// <summary>
    /// 
    /// </summary>
    public class CardCollectionFixture : TestsBaseFixture
    {
        public CardCollectionFixture() : base(dbNameSuffix: nameof(CardCollectionFixture))
        {
        }

    }
}