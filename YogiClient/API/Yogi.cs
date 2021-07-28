using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dascia.YogiClient.API
{
  internal class Yogi
  {
    private readonly HttpClient _client;
    private const string BaseUrl = "https://poopjournal.rocks/YogiBot/API/v2/api.php";

    /// <summary>
    /// Initializes a new instance of the <see cref="Yogi"/> class.
    /// </summary>
    public Yogi()
    {
      _client = new HttpClient();
    }


    /// <summary>
    /// Request a number of saying to yogi API in the language specified.
    /// Endpoint: ?command=filter_by_lang&lng=de
    /// </summary>
    /// <param name="language">The language.</param>
    /// <param name="quantity">The quantity.</param>
    public async Task<IList<Saying>> GetSaying(string language, int quantity)
    {
      string requestURI = $"{BaseUrl}?command=filter_by_lang&lng={language}&cnt={quantity}";
      string response = await Get(requestURI);
      IList<Saying> sayingCollection = System.Text.Json.JsonSerializer.Deserialize<IList<Saying>>(response) ?? new List<Saying>();
      return sayingCollection;
    }

    /// <summary>
    /// Gets a random saying in the language specified.
    /// </summary>
    /// <param name="language">The language.</param>
    /// <returns>Task&lt;IList&lt;Saying&gt;&gt;.</returns>
    public async Task<IList<Saying>> GetRandomSaying(string language, int quantity)
    {
      string requestUri = $"{BaseUrl}?command=get_random_one&lng={language}&cnt={quantity}";
      string response = await Get(requestUri);
      IList<Saying> sayingCollection = System.Text.Json.JsonSerializer.Deserialize<IList<Saying>>(response) ?? new List<Saying>();
      return sayingCollection;
    }

    /// <summary>
    /// Sends a get request to yogi API.
    /// </summary>
    /// <param name="requestUri">The endpoint.</param>
    /// <returns>System.String.</returns>
    private async Task<string> Get(string requestUri)
    {
      Trace.TraceInformation("Requesting to {0}", requestUri);
      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
      HttpResponseMessage response = _client.Send(request);
      response.EnsureSuccessStatusCode();
      string strResponse = await response.Content.ReadAsStringAsync();
      return strResponse;
    }
  }
}
