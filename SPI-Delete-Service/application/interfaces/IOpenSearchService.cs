using domain.models.openSearchModel;

namespace application.interfaces
{
    public interface IOpenSearchService
    {
        Task <OSDefinitive> SearchKey(string keyType, string keyValue);
        Task SaveKey(OSDefinitive osDefinitive);
        Task CancelledKey(string keyType, string keyValue, OSDefinitive oSDefinitive);
    }
}
