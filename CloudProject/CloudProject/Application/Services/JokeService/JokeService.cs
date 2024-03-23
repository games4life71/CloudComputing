using System.Text.Json;
using JokeAPIWrapper.Models;

namespace Application.Services.JokeService;

public class JokeService
{

    private readonly HttpClient _httpClient;
    private readonly JokeAPIWrapper.RequestBuilder _requestBuilder;
    public JokeService(HttpClient httpClient , JokeAPIWrapper.RequestBuilder requestBuilder)
    {
        _httpClient = httpClient;
        _requestBuilder = requestBuilder;
    }


    public async Task<(string,bool)> GetRandomJoke()
    {

        var request = _requestBuilder.WithCategory(JokeCategory.Programming).WithSafeMode().Build();

        var response = await _httpClient.GetAsync("https://v2.jokeapi.dev/joke/" + request.GetUri());

        if (!response.IsSuccessStatusCode)
        {
            return ("Error",false);
        }

        var content = await response.Content.ReadAsStringAsync();

        return(await response.Content.ReadAsStringAsync(),true);

    }

}