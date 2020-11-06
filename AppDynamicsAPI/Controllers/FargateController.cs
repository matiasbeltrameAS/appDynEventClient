using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YamlDotNet.RepresentationModel;

namespace AppDynamicsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FargateController : ControllerBase
    {
        [HttpGet("TestFargate")]
        public void GetContainerTaskStats(){
            var myJsonString = System.IO.File.ReadAllText(@"jsonFiles\CONTAINER_TASK_STATS.json");
            var myJObject = JObject.Parse(myJsonString);
            foreach (var feature in myJObject)
            {
                foreach (var children in feature.Value){
                    Console.Write(children);
                }
                
            }

            Console.Write(myJObject);
           // Console.WriteLine(myJObject.SelectToken("MyStringProperty").Value<string>());

            using (StreamReader file = System.IO.File.OpenText(@"jsonFiles\CONTAINER_TASK_STATS.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
               // var object = JsonSerializer.Deserialize<object>(myJsonString)
                var jsonString = JsonConvert.SerializeObject(o2);
                Console.Write(jsonString);
                var jsonObj = JsonConvert.DeserializeObject(jsonString);

                
                Console.Write(jsonObj);
            }
            
        }
    }
}