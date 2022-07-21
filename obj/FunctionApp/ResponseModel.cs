using Azure.Data.Tables;
namespace Hackathon.Models;

public class ResponseModel : TableEntity
{
    public int DeviceId { get; set; } = 0;

    public string Placement { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;
}