using Application.Services.CarInfoService;
using JsonSerializable;
using System.Text.Json;
namespace Application.Services.DriversInfoService;

public class DriverInfoService
{
    public async Task<(string, bool)> GetDriverInfo(string DriverName)
    {


        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://f1-live-motorsport-data.p.rapidapi.com/drivers/2024"),
            Headers =
            {
                { "X-RapidAPI-Key", "2e35499764msh8e3b6f2d1eda9e8p1cb078jsn4ff3cf62487e" },
                { "X-RapidAPI-Host", "f1-live-motorsport-data.p.rapidapi.com" },
            },
        };
        string body = " ";
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
             body = await response.Content.ReadAsStringAsync();
            // Console.WriteLine(body);
        }

        //deserializing the json response

        Root deserializedResponse = JsonSerializer.Deserialize<Root>(body);


        var driversMatched = deserializedResponse.results.FindAll(x=>x.driver_name.Contains(DriverName, StringComparison.CurrentCultureIgnoreCase));
        if(driversMatched.Count > 0)
        {
            return (JsonSerializer.Serialize(driversMatched), true);
        }
        
        return("Driver not found", false);



    }
}