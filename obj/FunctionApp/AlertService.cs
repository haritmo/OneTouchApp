using System.Threading.Tasks;

public class alertService : IAlertService
{
     private readonly IRepository _repository;

     public alertService(IRepository repository)
     {
         _repository = repository;
     }

     public Task<ResponseModel> CreateAlert(RequestModel request){
         return _repository.CreateAlert(request);
     }
}