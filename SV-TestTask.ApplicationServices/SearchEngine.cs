using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SV_TestTask.Common.Models;
using SV_TestTask.DataAccess.DataSource;

namespace SV_TestTask.ApplicationServices
{
    internal class SearchEngine : ISearchEngine
    {
        private class EntityWrapperWithRelevanceScore
        {
            public EntityBase Entity { get; set; }
            public int Score { get; set; }
            public string MostRelevantPropertyName { get; set; }
        }

        private readonly IDataSource _dataSource;

        public SearchEngine(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        public async Task<IEnumerable<EntityBase>> SearchByString(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}