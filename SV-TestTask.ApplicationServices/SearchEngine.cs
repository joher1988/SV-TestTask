using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SV_TestTask.Common;
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
            var entities = await _dataSource.GetAllEntitiesAsync();
            if (string.IsNullOrEmpty(searchString))
                return entities;
            var entityWrapperWithRelevanceScores = CalculateScore(entities,searchString).Where(entity => entity.Score > 0)
                .OrderByDescending(entity=>entity.Score);
            return entityWrapperWithRelevanceScores
                .Select(e=>e.Entity);
        }

        private static IEnumerable<EntityWrapperWithRelevanceScore> CalculateScore(IEnumerable<EntityBase> entities, string searchString)
        {
            var result = CalculateSelfScore(entities, searchString);
            UpdateScoreByTransitiveFields(result);

            return result;
        }

        private static void UpdateScoreByTransitiveFields(List<EntityWrapperWithRelevanceScore> result)
        {
            foreach (var entity in result)
            {
                var properties = entity.Entity.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var score = 0;
                    var attributes =
                        property.GetCustomAttributes(typeof(SearchEngineTransitiveRelevanceScoreAttribute), false) as
                            IEnumerable<SearchEngineTransitiveRelevanceScoreAttribute>;
                    if (attributes == null)
                        continue;
                    foreach (var attribute in attributes)
                    {
                        var propertyValue = (Guid) property.GetValue(entity.Entity);

                        if (result.Any(e =>
                                e.Entity.GetType().FullName == attribute.TransitivePropertyType.FullName &&
                                e.Entity.Id == propertyValue &&
                            attribute.TransitivePropertyName == e.MostRelevantPropertyName))
                            score = attribute.RelevanceScore;

                        if (score > entity.Score)
                        {
                            entity.Score = score;
                            entity.MostRelevantPropertyName = property.Name;
                        }
                    }
                }
            }
        }

        private static List<EntityWrapperWithRelevanceScore> CalculateSelfScore(IEnumerable<EntityBase> entities, string searchString)
        {
            var result = new List<EntityWrapperWithRelevanceScore>();
            foreach (var entity in entities)
            {
                var maxScore = 0;
                var mostRelevantProperty = "";
                var properties = entity.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var score = 0;
                    var ownAttribute =
                        property.GetCustomAttributes(typeof(SearchEngineOwnRelevanceScoreAttribute), false).FirstOrDefault() as
                            SearchEngineOwnRelevanceScoreAttribute;
                    if (ownAttribute == null)
                        continue;

                    var propertyValue = property.GetValue(entity)?.ToString().ToLower();
                    if(propertyValue == null)
                        continue;
                    if (propertyValue.Contains(searchString.ToLower()))
                        score = propertyValue == searchString.ToLower()
                            ? ownAttribute.RelevanceScore * 10
                            : ownAttribute.RelevanceScore;

                    if (score > maxScore)
                    {
                        maxScore = score;
                        mostRelevantProperty = property.Name;
                    }
                }

                result.Add(new EntityWrapperWithRelevanceScore()
                {
                    Entity = entity,
                    Score = maxScore,
                    MostRelevantPropertyName = mostRelevantProperty
                });
            }

            return result;
        }
    }
}