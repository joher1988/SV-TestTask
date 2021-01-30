using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using SV_TestTask.ApplicationServices;
using SV_TestTask.Common.Models;
using SV_TestTask.DataAccess.DataSource;
using Xunit;

namespace SV_TestTask.Tests
{
    public class SearchEngineTests
    {
        [Fact]
        public async Task ShouldReturnTransitiveFields()
        {
            var buildingId = Guid.NewGuid();
            var building = new Building() { Id = buildingId, Name = "head"};
            var lockEntity = new Lock(){BuildingId = buildingId};
            
            var dataSourceMock = new Mock<IDataSource>();
            dataSourceMock.Setup(source => source.GetAllEntitiesAsync())
                .ReturnsAsync(() => new EntityBase[] {building, lockEntity});

            var searchEngine = new SearchEngine(dataSourceMock.Object);

            var result = await searchEngine.SearchByString("head");

            Assert.Equal(new EntityBase[] { building, lockEntity }, result);
        }
        [Fact]
        public async Task ShouldIgnoreNotMatchedEntity()
        {
            var buildingId = Guid.NewGuid();
            var building = new Building() { Id = buildingId, Name = "head" };
            var lockEntity = new Lock();

            var dataSourceMock = new Mock<IDataSource>();
            dataSourceMock.Setup(source => source.GetAllEntitiesAsync())
                .ReturnsAsync(() => new EntityBase[] { building, lockEntity });

            var searchEngine = new SearchEngine(dataSourceMock.Object);

            var result = await searchEngine.SearchByString("head");

            Assert.DoesNotContain(lockEntity, result);
        }
    }
}