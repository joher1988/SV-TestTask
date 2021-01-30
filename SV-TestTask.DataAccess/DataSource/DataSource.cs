using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SV_TestTask.Common.Models;

namespace SV_TestTask.DataAccess.DataSource
{
    internal class DataSource : IDataSource
    {
        private List<EntityBase> _entities;
        public const string DataSourceFilepath = "sv_lsm_data.json";
        
        private async Task LoadContent()
        {
            var fileSchema = new
            {
                buildings = new Building[] { },
                locks = new Lock[] { },
                groups = new Group[] { },
                media = new Medium[] { }
            };
            var fileContent = JsonConvert.DeserializeAnonymousType(await File.ReadAllTextAsync(DataSourceFilepath), fileSchema);

            _entities = new List<EntityBase>();
            _entities.AddRange(fileContent.buildings);
            _entities.AddRange(fileContent.groups);
            _entities.AddRange(fileContent.media);
            _entities.AddRange(fileContent.locks);

        }

        public async Task<IReadOnlyCollection<EntityBase>> GetAllEntitiesAsync()
        {
            if (_entities == null)
            {
                await LoadContent();
            }

            return _entities.ToList().AsReadOnly();
        }
    }
}