using System.Collections.Generic;
using System.Threading.Tasks;
using SV_TestTask.Common.Models;

namespace SV_TestTask.ApplicationServices
{
    public interface ISearchEngine
    {
        Task<IEnumerable<EntityBase>> SearchByString(string searchString);
    }
}
