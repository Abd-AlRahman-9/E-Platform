using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Writers
{
    public class JsonFileWriter
    {
        public static void WriteFile<T>(string path, IEnumerable<T> data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            });

            File.WriteAllText(path, json);
        }
    }
}
