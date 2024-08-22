using Confluent.Kafka;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

var config = new ConsumerConfig
{
    GroupId = "weather-consumer-group",
    BootstrapServers = "localhost:9092",
    AutoOffsetReset = AutoOffsetReset.Earliest,
};
using var consumer = new ConsumerBuilder<Null, string>(config).Build();
consumer.Subscribe("weather-topic");
CancellationTokenSource token = new CancellationTokenSource();

try
{
    while (true)
    {
        var response = consumer.Consume(token.Token);
        if (response != null)
        {
            var weather = JsonConvert.DeserializeObject<Weather>(response.Message.Value);
            Console.WriteLine($"State: {weather.State}, Temperature: {weather.Temperature}");
        }
    }
}
catch (Exception)
{
    throw;
}
public record Weather(string State, int Temperature);