namespace Models.Http;
public class RequestModel
{
    public int DeviceId { get; set; } = 0;

    public string Placement { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; } = null;
}
