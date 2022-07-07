using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Business.Models
{
    public abstract class Entity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAtualizacao { get; set; }


        public Entity()
        {
            Id = Guid.NewGuid().ToString();
            DataCriacao = DateTime.UtcNow;
        }
    }
}
