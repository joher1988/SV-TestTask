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
                media = new Medium[] { }
            };
            var fileContent = JsonConvert.DeserializeAnonymousType(await File.ReadAllTextAsync(DataSourceFilepath), fileSchema);

            var lockGroups = fileContent.locks.GroupBy(lockEntry => lockEntry.BuildingId);
            _buildings = fileContent.buildings.Select(building =>
            {
                building.Locks = lockGroups.FirstOrDefault(locks => locks.Key == building.Id)?.ToList() ??
                                 new List<Lock>();
                return building;
            }).ToList();

            var mediumGroups = fileContent.media.GroupBy(medium => medium.GroupId);
            _groups = fileContent.groups.Select(group =>
            {
                group.Media = mediumGroups.FirstOrDefault(medium => medium.Key == group.Id)?.ToList() ??
                                new List<Medium>();
                return group;
            }).ToList();
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