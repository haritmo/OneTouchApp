using System.Threading.Tasks;

namespace Alert.Service.Interface;

public interface IAlertService
{
public Task<ResponseModel> CreateAlert(int deviceId);
}
