using System.Threading.Tasks;

public class alertService : IAlertService
{
     private readonly IRepository _repository;

     public alertService(IRepository repository)
     {
         _repository = repository;
     }

     public Task<ResponseModel> CreateAlert(int deviceId, string placement, DateTime timestamp)
    {
         return _repository.CreateAlert(deviceId, placement,timestamp);
            
     }
}