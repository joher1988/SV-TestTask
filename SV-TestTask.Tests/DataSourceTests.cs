using System;
using System.Threading.Tasks;
using SV_TestTask.DataAccess.DataSource;
using Xunit;

namespace SV_TestTask.Tests
{
    public class DataSourceTests
    {
        [Fact]
        public async Task ShouldReturnsEntities()
        {
            var result = await new DataSource().GetAllEntitiesAsync();

            Assert.NotEmpty(result);
        }
    }
}
