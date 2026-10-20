namespace Backend.Services
{
    public class CityRandomizer
    {
        public int? SelectNextCityId(IEnumerable<int> recentCityIds, IEnumerable<int> eligibleCityIds)
        {
            var allCityIds = eligibleCityIds.Distinct().ToList();

            if (allCityIds.Count == 0)
            {
                return null;
            }

            var recentIds = recentCityIds.ToList();
            var recentSet = recentIds.ToHashSet();

            var availableCityIds = allCityIds
                .Where(id => !recentSet.Contains(id))
                .ToList();

            if (availableCityIds.Count == 0)
            {
                availableCityIds = allCityIds.ToList();

                if (availableCityIds.Count > 1 && recentIds.Count > 0)
                {
                    availableCityIds.Remove(recentIds.Last());
                }
            }

            var randomIndex = Random.Shared.Next(availableCityIds.Count);

            return availableCityIds[randomIndex];
        }
        // OLD SCRAPPED RANDOMIZER FUNCTION, KEPT FOR REFERENCE

        //public int? SelectNextCityId(IEnumerable<int> recentCityIds, int totalCities)
        //{
        //    if(totalCities <= 0)
        //    {
        //        return null;
        //    }

        //    // List with all available city IDs
        //    var availableCityIds = Enumerable.Range(1, totalCities).ToList();

        //    // Remove recently used city IDs from the available list
        //    if (recentCityIds != null && recentCityIds.Any())
        //    {
        //        var recentSet = recentCityIds.ToHashSet();
        //        availableCityIds.RemoveAll(id => recentSet.Contains(id));
        //    }

        //    // If all cities have been used recently, reset the available list and exclude the last used city
        //    if (!availableCityIds.Any())
        //    {
        //        availableCityIds = Enumerable.Range(1, totalCities).ToList();
        //        var lastCityId = recentCityIds?.LastOrDefault();

        //        if(lastCityId.HasValue && totalCities > 1)
        //        {
        //            availableCityIds.Remove(lastCityId.Value);
        //        }
        //    }

        //    // Select a random city ID from the available list 
        //    var random = new Random();
        //    int randomIndex = random.Next(availableCityIds.Count);

        //    return availableCityIds[randomIndex];
        //}
    }
}
