using System.Text.Json.Serialization;

namespace Dascia.YogiClient.API
{
  public class Saying
  {
    [JsonPropertyNameAttribute("number")]
    public string? Number { get; set; }
    [JsonPropertyNameAttribute("language")]
    public string? Language { get; set; }
    [JsonPropertyNameAttribute("saying")]
    public string? Text { get; set; }
    [JsonPropertyNameAttribute("comment")]
    public string? Comment { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Saying"/> class.
    /// </summary>
    public Saying()
    { }
  }
}
