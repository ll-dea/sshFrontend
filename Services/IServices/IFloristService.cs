namespace SSH_FrontEnd.Services.IServices
{
    public interface IFloristService
    {
        Task<T> GetAllAsync<T>();

    }
}
