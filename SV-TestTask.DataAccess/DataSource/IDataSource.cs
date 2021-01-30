using System.Collections.Generic;
using System.Threading.Tasks;
using SV_TestTask.Common.Models;

namespace SV_TestTask.DataAccess.DataSource
{
    public interface IDataSource
    {
        Task<IReadOnlyCollection<EntityBase>> GetAllEntitiesAsync();
    }
}