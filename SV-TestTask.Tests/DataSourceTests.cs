using System;
using System.Threading.Tasks;
using SV_TestTask.DataAccess.DataSource;
using Xunit;

namespace SV_TestTask.Tests
{
    public class DataSourceTests
    {
        [Fact]
        public async Task ShouldReturnsBuildings()
        {
            var result = await new DataSource().GetBuildingsAsync();

            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ShouldReturnsGroups()
        {
            var result = await new DataSource().GetGroupsAsync();

            Assert.NotEmpty(result);
        }
    }
}
