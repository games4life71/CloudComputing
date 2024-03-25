using System.Text;
using Microsoft.Extensions.Primitives;

namespace Application.Services.CarInfoService;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Fields
{
    public string driver_id { get; set; }
    public string driver_name { get; set; }
    public string is_reserve { get; set; }
    public string nationality { get; set; }
    public string season { get; set; }
    public string team_id { get; set; }
    public string team_name { get; set; }
    public string updated { get; set; }
}

public class Meta
{
    public string description { get; set; }
    public Fields fields { get; set; }
    public string title { get; set; }
}

public class Result
{
    public int driver_id { get; set; }
    public string driver_name { get; set; }
    public int is_reserve { get; set; }
    public string nationality { get; set; }
    public int season { get; set; }
    public int team_id { get; set; }
    public string team_name { get; set; }
    public string updated { get; set; }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Driver ID: {driver_id}");
        sb.AppendLine($"Driver Name: {driver_name}");
        sb.AppendLine($"Is Reserve: {is_reserve}");
        sb.AppendLine($"Nationality: {nationality}");
        sb.AppendLine($"Season: {season}");
        sb.AppendLine($"Team ID: {team_id}");
        sb.AppendLine($"Team Name: {team_name}");

        return sb.ToString();
    }
}

public class Root
{
    public Meta meta { get; set; }
    public List<Result> results { get; set; }
}