using System;
using MongoDB.Driver;

Console.WriteLine("Hola Mundo, VS2026 + MongoDB");

var mongoUrl = Environment.GetEnvironmentVariable("MONGODB_URI");
var client = new MongoClient(mongoUrl);

Console.WriteLine("Conectando a MongoDB...");
var dbList = client.ListDatabaseNames().ToList();

Console.WriteLine("Conexión establecida con MongoDB.");

Console.WriteLine("Bases de datos disponibles:");
foreach (var dbName in dbList)
{
    Console.WriteLine($" - {dbName}");
}
