﻿using AutoMapper;
using NSubstitute;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Notifications;

namespace TaskoMask.Services.Identity.Application.Tests.Unit.TestData
{
    public abstract class TestsBase : IDisposable
    {

        protected IInMemoryBus _inMemoryBus;
        protected IMapper _iMapper;
        protected INotificationHandler _domainNotificationHandler;



        /// <summary>
        /// Run before each test method
        /// </summary>
        public TestsBase()
        {
            FixtureSetup();
        }



        /// <summary>
        /// 
        /// </summary>
        private void FixtureSetup()
        {
            CommonFixtureSetup();

            TestClassFixtureSetup();
        }



        /// <summary>
        /// 
        /// </summary>
        private void CommonFixtureSetup()
        {
            _inMemoryBus = Substitute.For<IInMemoryBus>();
            _iMapper = Substitute.For<IMapper>();
            _domainNotificationHandler = Substitute.For<INotificationHandler>();
        }



        /// <summary>
        /// Each test class should setup its fixture
        /// </summary>
        protected abstract void TestClassFixtureSetup();



        /// <summary>
        /// Run after each test method
        /// </summary>
        public void Dispose()
        {

        }

    }
}
