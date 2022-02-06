using System.Net;
using Confluent.Kafka;

Console.WriteLine("Kafk Consumer Running");

var kafkaConfig = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "consumer",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Ignore, string>(kafkaConfig).Build();

consumer.Subscribe("example-topic");

while (true)
{
    var result = consumer.Consume();

    Console.WriteLine($"Offset: {result.Offset}. Key: {result.Key}. Value: {result.Value}.");
}

consumer.Close();