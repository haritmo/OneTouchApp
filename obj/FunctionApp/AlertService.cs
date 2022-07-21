using System.Threading.Tasks;
using Alert.Repository.Interface;

namespace Alert.Service;

public class alertService : IAlertService
{
     private readonly IRepository _repository;

     public alertService(IRepository repository)
     {
         _repository = repository;
     }

     public Task<ResponseModel> CreateAlert(int deviceId)
    {
         return _repository.CreateAlert(deviceId);
            
     }
}