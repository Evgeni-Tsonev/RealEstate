using RealEstates.Data;
namespace RealEstates.Services
{
    using RealEstates.Models;

    public class TagService : ITagService
    {
        private readonly ApplicationDbContext dbContext;

        public TagService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void AddTag(string name, int? importance = null)
        {
            var tag = new Tag
            {
                Name = name,
                Importance = importance
            };

            dbContext.Tags.Add(tag);
            dbContext.SaveChanges();
        }

        public void BulkTagToPropertiesRelation()
        {
            throw new NotImplementedException();
        }
    }
}
