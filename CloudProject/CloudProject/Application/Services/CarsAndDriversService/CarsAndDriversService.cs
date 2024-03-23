using System.Text;
using System.Text.Json;

namespace Application.Services.CarsAndDriversService;

public class CarsAndDriversService
{
    private readonly HttpClient _httpClient;

    public CarsAndDriversService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<(string, bool)> GetCars()
    {
        try
        {
            var response = await _httpClient.GetAsync("http://localhost:8000/cars");

            if (!response.IsSuccessStatusCode)
            {
                return ("An error occured", false);
            }

            return (await response.Content.ReadAsStringAsync(), true);
        }
        catch (Exception e)
        {
            return (e.Message, false);
        }
    }


    public async Task<(string, bool)> GetCarById(Guid id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"http://localhost:8000/cars/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return ("An error occured", false);
            }

            return (await response.Content.ReadAsStringAsync(), true);
        }
        catch (Exception e)
        {
            return (e.Message, false);
        }
    }

    public async Task<(string, bool)> DeleteCar(Guid id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:8000/cars/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return ("An error occured", false);
            }

            return (await response.Content.ReadAsStringAsync(), true);
        }
        catch (Exception e)
        {
            return (e.Message, false);
        }
    }


    public async Task<(string, bool)> AddCar(string requestName, int requestYear, int requestSpeed)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8000/cars");
        request.Content =
            new StringContent(
                JsonSerializer.Serialize(new { name = requestName, year = requestYear, speed = requestSpeed }),
                Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadAsStringAsync(), false);
        }

        return (await response.Content.ReadAsStringAsync(), true);
    }

    public async Task<(string, bool)> UpdateCar(Guid id, string requestName, int requestYear, int requestSpeed)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, $"http://localhost:8000/cars/{id}");
        request.Content =
            new StringContent(
                JsonSerializer.Serialize(new { name = requestName, year = requestYear, speed = requestSpeed }),
                Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadAsStringAsync(), false);
        }

        return (await response.Content.ReadAsStringAsync(), true);
    }


    public async Task<(string, bool)> GetDrivers()
    {
        try
        {
            var response = await _httpClient.GetAsync("http://localhost:8000/drivers");

            if (!response.IsSuccessStatusCode)
            {
                return ("An error occured", false);
            }

            return (await response.Content.ReadAsStringAsync(), true);
        }
        catch (Exception e)
        {
            return (e.Message, false);
        }
    }

    public async Task<(string, bool)> GetDriverById(Guid id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"http://localhost:8000/drivers/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return ("An error occured", false);
            }

            return (await response.Content.ReadAsStringAsync(), true);
        }
        catch (Exception e)
        {
            return (e.Message, false);
        }
    }

    public async Task<(string, bool)> DeleteDriver(Guid id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:8000/drivers/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return ("An error occured", false);
            }

            return (await response.Content.ReadAsStringAsync(), true);
        }
        catch (Exception e)
        {
            return (e.Message, false);
        }
    }

    public async Task<(string, bool)> AddDriver(string requestName, string requestTeam)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8000/drivers");
            request.Content =
                new StringContent(JsonSerializer.Serialize(new { name = requestName, team = requestTeam }),
                    Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadAsStringAsync(), false);
            }

            return (await response.Content.ReadAsStringAsync(), true);
        }
        catch (Exception e)
        {
            return (e.Message, false);
        }
    }

    public async Task<(string, bool)> UpdateDriver(Guid id, string requestName, string requestTeam)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"http://localhost:8000/drivers/{id}");
            request.Content =
                new StringContent(JsonSerializer.Serialize(new { name = requestName, team = requestTeam }),
                    Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadAsStringAsync(), false);
            }

            return (await response.Content.ReadAsStringAsync(), true);
        }
        catch (Exception e)
        {
            return (e.Message, false);
        }
    }
}