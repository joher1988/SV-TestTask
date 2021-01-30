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
        private List<Building> _buildings;
        private List<Group> _groups;
        public const string DataSourceFilepath = "sv_lsm_data.json";
        public async Task<IReadOnlyCollection<Building>> GetBuildingsAsync()
        {
            if (_buildings == null)
            {
                await LoadContent();
            }

            return _buildings.AsReadOnly();
        }

        private async Task LoadContent()
        {
            var fileSchema = new
            {
                buildings = new Building[] { },
                locks = new Lock[] { },
                groups = new Group[] { },
                mediums = new Medium[] { }
            };
            var fileContent = JsonConvert.DeserializeAnonymousType(await File.ReadAllTextAsync(DataSourceFilepath), fileSchema);

            var lockGroups = fileContent.locks.GroupBy(lockEntry => lockEntry.BuildingId);
            foreach (var building in _buildings)
            {
                building.Locks = lockGroups.FirstOrDefault(locks => locks.Key == building.Id)?.ToList() ??
                                 new List<Lock>();
            }

            var mediumGroups = fileContent.mediums.GroupBy(medium => medium.GroupId);
            foreach (var group in _groups)
            {
                group.Mediums = mediumGroups.FirstOrDefault(medium => medium.Key == group.Id)?.ToList() ??
                                new List<Medium>();
            }
        }

        public async Task<IReadOnlyCollection<Group>> GetGroupsAsync()
        {
            if (_groups == null)
            {
                await LoadContent();
            }

            return _groups.ToList().AsReadOnly();
        }
    }
}