namespace Hackathon.Services;

using System.Threading.Tasks;

public interface IAlertService
{
public Task<ResponseModel> CreateAlert(RequestModel request);
}
