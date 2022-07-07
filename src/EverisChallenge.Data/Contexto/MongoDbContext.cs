using EverisChallenge.Business.Models;
using Microsoft.IdentityModel.Protocols;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Data.Contexto
{
    public class MongoDbContext
    {
        public MongoDatabase Database;
        public String DataBaseName = "TelefoneDB";
        string conexaoMongoDB = "";

        public MongoDbContext()
        {

            conexaoMongoDB = "mongodb://localhost:27017/EverisChallenge";
            var cliente = new MongoClient(conexaoMongoDB);
            var server = cliente.GetServer();

            Database = server.GetDatabase(DataBaseName);
        }

        public MongoCollection<Telefone> Telefone
        {
            get
            {
                var Paises = Database.GetCollection<Telefone>("Telefone");
                return Paises;
            }
        }
    }
}
