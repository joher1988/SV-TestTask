using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SV_TestTask.Common.Models;

namespace SV_TestTask.ApplicationServices
{
    internal class SearchEngine : ISearchEngine
    {
        public Task<IEnumerable<EntityBase>> SearchByString(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}