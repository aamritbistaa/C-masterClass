using Confluent.Kafka;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092",
};
using var producer = new ProducerBuilder<Null, string>(config).Build();

try
{
    string? state;
    int? temp;
    while ((state = Console.ReadLine()) != null & (temp = int.Parse(Console.ReadLine() ?? "0")) != null)
    {
        var response = await producer.ProduceAsync("weather-topic", new Message<Null, string> { Value = JsonConvert.SerializeObject(new Weather((string)state, (int)temp)) });
        Console.WriteLine(response);
    }
}
catch (ProduceException<Null, string> exc)
{
    throw new Exception(exc.Message);
}
public record Weather(string State, int Temperature);