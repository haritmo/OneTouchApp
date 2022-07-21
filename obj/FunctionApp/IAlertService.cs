namespace Hackathon.Services;

using System.Threading.Tasks;

public interface IAlertService
{
public Task<ResponseModel> CreateAlert(int deviceId, string placement, DateTime timestamp);
}
