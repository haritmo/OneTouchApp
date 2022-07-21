using System.Threading.Tasks;

namespace Alert.Repository.Interface;
public interface IRepository
{
    public Task<ResponseModel> CreateAlert(int deviceId);
}