using RealEstates.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services
{
    public class DistrictsService : IDistrictsService
    {
        private readonly ApplicationDbContext dbContext;

        public DistrictsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count)
        {
            var districts = dbContext.Districts
                .Select(x => new DistrictInfoDto 
                {
                    Name = x.Name,
                    AveragePricePerSquareMeter = 
                    x.Properties.Where(p => p.Price.HasValue)
                    .Average(p => p.Price / (decimal)p.Size) ?? 0,
                    PropertiesCount = x.Properties.Count()
                })
                .OrderByDescending(x => x.PropertiesCount)
                .Take(count)
                .ToList();

            return districts;
        }
    }
}
