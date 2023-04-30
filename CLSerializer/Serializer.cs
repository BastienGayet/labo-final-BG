
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Xml.Linq;
using CLGestionBibliotheque;

namespace CLSerializer
{
    public class Serializer
    {
      /* public static void SerializeBin(MyData data, String filename)
        {
            System.IO.Stream ms = File.OpenWrite(filename);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, data);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

        public static MyData DeserializeBin(String filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using FileStream fs = File.Open(filename, FileMode.Open);
            object obj = formatter.Deserialize(fs);
            MyData data = (MyData)obj;
            fs.Flush();
            fs.Close();
            fs.Dispose();

            return data;
        }*/

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