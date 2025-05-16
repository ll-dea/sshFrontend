namespace SSH_FrontEnd.Services.IServices
{
    public interface IVenueService : IBaseServices
    {
        Task<T> GetAllAsync<T>();
    }
}
