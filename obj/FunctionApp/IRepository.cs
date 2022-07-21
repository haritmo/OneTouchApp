using System.Threading.Tasks;

public interface IRepository
{
    public Task<ResponseModel> CreateAlert(RequestModel request);
}