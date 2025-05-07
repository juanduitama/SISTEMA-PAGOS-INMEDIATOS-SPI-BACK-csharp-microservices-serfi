using Models.openSearchModel;

namespace Services
{
    public interface IOpenSearchService
    {
        Task <OSDefinitive> SearchKey(string keyType, string keyValue);
        Task <void> SaveKey(OSDefinitive osDefinitive);
    }
}
