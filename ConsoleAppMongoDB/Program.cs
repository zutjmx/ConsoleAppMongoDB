using MongoDB.Driver;
using MongoDB.Bson;
using ConsoleAppMongoDB.Models;

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


Console.WriteLine("Nos aseguramos de tener la base de datos y colección correctas:");
var database = client.GetDatabase("test");

// Querying a MongoDB Collection in C# Applications

var accountsCollection = database.GetCollection<Account>("account");

var account = accountsCollection
   .Find(a => a.AccountId == "MDB829001337")
   .FirstOrDefault();

Console.WriteLine($"Cuenta encontrada: {account?.AccountHolder}, Balance: {account?.Balance}");

Console.WriteLine("Lista de cuentas:");
var accounts = accountsCollection.Find(_ => true).ToList();
foreach (var item in accounts)
{
    Console.WriteLine(item.AccountHolder);
}

// Usando la clase Account para representar un documento de cuenta bancaria
//var accountsCollection = database.GetCollection<Account>("account");
//Console.WriteLine("Creando una nueva cuenta...");
//var newAccount = new Account
//{
//    AccountId = "MDB829001337",
//    AccountHolder = "Linus Torvalds",
//    AccountType = "checking",
//    Balance = 50352434
//};

//Console.WriteLine("Insertando la nueva cuenta en la colección...");
//accountsCollection.InsertOne(newAccount);
//Console.WriteLine("Nueva cuenta insertada en la colección.");

// Usando el objeto BsonDocument para insertar un documento directamente
//var accountsCollectionBson = database.GetCollection<BsonDocument>("account");
//Console.WriteLine("Creando una nueva cuenta...");
//var document = new BsonDocument
//{
//   { "account_id", "MDB829001338" },
//   { "account_holder", "Ada Lovelace" },
//   { "account_type", "checking" },
//   { "balance", 79352434 }
//};

//Console.WriteLine("Insertando la nueva cuenta en la colección...");
//accountsCollectionBson.InsertOne(document);
//Console.WriteLine("Nueva cuenta insertada en la colección.");
