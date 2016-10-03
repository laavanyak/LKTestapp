using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LKTestapp.Controllers
{
    public class PersonController : ApiController
    {
        // GET api/values
        public List<BsonDocument> Get()
        {
            var client = new MongoClient("mongodb://lkdbdataadmin:admindata@ds044989.mlab.com:44989/lkdb");
            var database = client.GetDatabase("lkdb");
            var collection = database.GetCollection<BsonDocument>("People");
            var documents = collection.Find(new BsonDocument()).ToList();
            return documents;
        }

        // GET api/values/5
        public BsonDocument Get([FromUri] string name)
        {

            return new BsonDocument {
                { "name",  name }
            };
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            var client = new MongoClient("mongodb://lkdbdataadmin:admindata@ds044989.mlab.com:44989/lkdb");
            var database = client.GetDatabase("lkdb");
            var collection = database.GetCollection<BsonDocument>("People");
            var count = collection.Count(new BsonDocument());
            var person = new BsonDocument {
                { "name", "karthik" },
                { "age", 36 },
                { "gender", "male" },
                { "subjects", new BsonArray {
                        new BsonDocument {
                            { "name", "maths"},
                            { "mark", 100}
                        },
                        new BsonDocument {
                            { "name", "science"},
                            { "mark", 96}
                        }
                    }
                },
                { "ID", new BsonDocument {
                        { "id", 234} ,
                        { "longid", 23456}
                    }
                }
            };
            collection.InsertOne(person);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
