﻿using eShopCloudNative.Architecture.Data.Repositories;
using eShopCloudNative.Catalog.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopCloudNative.Architecture.Tests.Data;

public class TestEntity : IEntity
{ 

}

public class PersistenseRepositoryTests
{
    [Fact]
    public Task ConstructorTest()
    {
        var mock = new Mock<ISession>();
        ISession session = mock.Object;
        
        var persistenseRepository = new PersistenseRepository<TestEntity>(session);
        return Task.CompletedTask;
    }

    [Fact]
    public async Task TestSaveAsync()
    {
        Mock<ISession> mock = new Mock<ISession>();

        ISession session = mock.Object;

        var persistenseRepository = new PersistenseRepository<TestEntity>(session);

        var instance = new TestEntity();

        await persistenseRepository.SaveAsync(instance);

        mock.Verify(x => x.SaveAsync(It.Is<TestEntity>(it => it == instance), It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task TestUpdateAsync()
    {
        Mock<ISession> mock = new Mock<ISession>();

        ISession session = mock.Object;

        var persistenseRepository = new PersistenseRepository<TestEntity>(session);

        var instance = new TestEntity();

        await persistenseRepository.UpdateAsync(instance);

        mock.Verify(x => x.UpdateAsync(It.Is<TestEntity>(it => it == instance), It.IsAny<CancellationToken>()), Times.Once());

    }

    [Fact]
    public async Task TestDeleteAsync()
    {
        Mock<ISession> mock = new Mock<ISession>();

        ISession session = mock.Object;

        var persistenseRepository = new PersistenseRepository<TestEntity>(session);

        var instance = new TestEntity();

        await persistenseRepository.DeleteAsync(instance);

        mock.Verify(x => x.DeleteAsync(It.Is<TestEntity>(it => it == instance), It.IsAny<CancellationToken>()), Times.Once());
    }

}
