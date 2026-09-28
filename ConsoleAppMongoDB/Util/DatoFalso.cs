using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using ConsoleAppMongoDB.Models;

namespace ConsoleAppMongoDB.Util
{
    internal class DatoFalso
    {
        public DatoFalso()
        {
            
        }

        public Account GenerarCuentaFalsa()
        {
            var cuentaFalsa = new Account
            {
                AccountId = Faker.Identification.BulgarianPin(),
                AccountHolder = Faker.Name.FullName(),
                AccountType = Faker.Lorem.Paragraph(10),
                Balance = Faker.RandomNumber.Next(1000, 10000)
            };
            return cuentaFalsa;
        }

        public BsonDocument GeneraCuentaFalsaBson()
        {
            var cuentaFalsa = new BsonDocument
            {
                { "account_id", Faker.Identification.BulgarianPin() },
                { "account_holder", Faker.Name.FullName() },
                { "account_type", Faker.Lorem.Paragraph(10) },
                { "balance", Faker.RandomNumber.Next(1000, 10000) }
            };
            return cuentaFalsa;
        }

    }
}
