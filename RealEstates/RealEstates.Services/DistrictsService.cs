namespace RealEstates.Services
{
    using AutoMapper.QueryableExtensions;
    using RealEstates.Data;

    public class DistrictsService : BaseService, IDistrictsService
    {
        private readonly ApplicationDbContext dbContext;

        public DistrictsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count)
        {
            var districts = dbContext.Districts
                .ProjectTo<DistrictInfoDto>(this.Mapper.ConfigurationProvider)
                .OrderByDescending(x => x.PropertiesCount)
                .Take(count)
                .ToList();

            return districts;
        }
    }
}
