namespace RealEstates.Services
{
    public interface ITagService
    {
        void AddTag(string name, int? importance = null);

        void BulkTagToPropertiesRelation();
    }
}
