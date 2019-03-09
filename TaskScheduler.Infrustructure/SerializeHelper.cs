using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskScheduler.Infrustructure
{
    public static class SerializeHelper
    {
        public static JsonSerializerSettings SerializeSettings => 
            new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        public static string Serialize<T>(this T entity) => 
            JsonConvert.SerializeObject(entity, SerializeSettings);

        public static T Deserialize<T>(this string message) =>
            JsonConvert.DeserializeObject<T>(message, SerializeSettings);

    }
}
