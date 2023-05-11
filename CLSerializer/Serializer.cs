
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Xml.Linq;
using CLGestionBibliotheque;

namespace CLSerializer
{
    public class Serializer
    {
        
        public static void SerializeJson(MyData data, String filename)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            File.WriteAllText(filename, JsonSerializer.Serialize(data, options));
        }

        public static MyData DeserializeJson(String fileName)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            return JsonSerializer.Deserialize<MyData>(File.ReadAllText(fileName), options)!;
        }

    }
}