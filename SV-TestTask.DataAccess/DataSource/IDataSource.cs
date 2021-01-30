using System.Collections.Generic;
using System.Threading.Tasks;
using SV_TestTask.Common.Models;

namespace SV_TestTask.DataAccess.DataSource
{
    internal interface IDataSource
    {
        Task<IReadOnlyCollection<Building>> GetBuildingsAsync();
        Task<IReadOnlyCollection<Group>> GetGroupsAsync();
    }
}