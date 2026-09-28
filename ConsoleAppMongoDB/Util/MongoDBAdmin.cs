using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using ConsoleAppMongoDB.Models;


namespace ConsoleAppMongoDB.Util
{
    internal class MongoDBAdmin
    {
        public MongoDBAdmin()
        {
            
        }

        public void ListarBasesDeDatos()
        {
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
        }

        public void ConsultarDocumentos()
        {
            Console.WriteLine("Hola Mundo, VS2026 + MongoDB, consultar documentos de cuenta");
            var mongoUrl = Environment.GetEnvironmentVariable("MONGODB_URI");
            var client = new MongoClient(mongoUrl);

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
        }

        public void InsertarDocumentos()
        {
            var mongoUrl = Environment.GetEnvironmentVariable("MONGODB_URI");
            var client = new MongoClient(mongoUrl);

            Console.WriteLine("Nos aseguramos de tener la base de datos y colección correctas:");
            var database = client.GetDatabase("test");

            // Usando la clase Account para representar un documento de cuenta bancaria
            var accountsCollection = database.GetCollection<Account>("account");
            Console.WriteLine("Creando una nueva cuenta...");
            DatoFalso datoFalso = new DatoFalso();

            var newAccount = datoFalso.GenerarCuentaFalsa();

            Console.WriteLine("Insertando la nueva cuenta en la colección...");
            accountsCollection.InsertOne(newAccount);
            Console.WriteLine("Nueva cuenta insertada en la colección.");

            // Usando el objeto BsonDocument para insertar un documento directamente
            var accountsCollectionBson = database.GetCollection<BsonDocument>("account");
            Console.WriteLine("Creando una nueva cuenta...");
            var document = datoFalso.GeneraCuentaFalsaBson();

            Console.WriteLine("Insertando la nueva cuenta en la colección...");
            accountsCollectionBson.InsertOne(document);
            Console.WriteLine("Nueva cuenta insertada en la colección.");
        }
    }
}
