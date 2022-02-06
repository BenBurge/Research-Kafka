using System.Net;
using Confluent.Kafka;

Console.WriteLine("Kafka Producer Running.");

var kafkaConfig = new ProducerConfig{
    BootstrapServers = "localhost:9092",
    ClientId = $"Producer-{Dns.GetHostName()}"
};

using var producer = new ProducerBuilder<Null, string>(kafkaConfig).Build();
Random rnd = new();

while(true){
    var result = await producer.ProduceAsync("example-topic", new Message<Null, string> { Value = $"Timestamp {DateTime.UtcNow}" });

    Console.WriteLine($"Current offset {result.Offset}");

    Thread.Sleep(rnd.Next(500, 2000));
}