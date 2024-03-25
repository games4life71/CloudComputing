namespace Application.Services.CarInfoService;

public class CarInfoService
{
    public async Task<(string, bool)> GetCarInfo(string CarModel,string CarMake)
    {
        var client = new HttpClient();

        //add special character for space
        CarModel = CarModel.Replace(" ", "%20");
        CarMake = CarMake.Replace(" ", "%20");

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://cars-by-api-ninjas.p.rapidapi.com/v1/cars?model={CarModel}&make={CarMake}&limit=1"),
            // RequestUri = new Uri("https://cars-by-api-ninjas.p.rapidapi.com/v1/cars?model=model%203&make=tesla&limit=1"),
            Headers =
            {
                { "X-RapidAPI-Key", "2e35499764msh8e3b6f2d1eda9e8p1cb078jsn4ff3cf62487e" },
                { "X-RapidAPI-Host", "cars-by-api-ninjas.p.rapidapi.com" },
            },
        };
        using var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();
        Console.WriteLine(body);

        return body.Length <3 ? ("Error", false) :
            // Console.WriteLine(body);
            (body, true);
    }
}