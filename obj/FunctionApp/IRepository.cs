using System.Threading.Tasks;

public interface IRepository
{
    public Task<ResponseModel> CreateAlert(int deviceId, string placement, DateTime timestamp);
}