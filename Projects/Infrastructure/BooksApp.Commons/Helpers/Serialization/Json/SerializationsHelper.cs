using System.Text.Encodings.Web;
using System.Text.Json;

namespace BooksApp.Commons.Helpers.Serialization.Json
{
    public class SerializationsHelper
    {
        public JsonSerializerOptions SerializerSettings { get; private set; }


        public SerializationsHelper()
        {
            SerializerSettings = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
        }

        public SerializationsHelper(JsonSerializerOptions serializerSettings)
        {
            SerializerSettings = serializerSettings;
        }

        public SerializationsHelper(bool useFormatting) : this()
        {
            if (useFormatting)
                SerializerSettings.WriteIndented = useFormatting;
        }


        public string Serialize(object entity)
        {
            return JsonSerializer.Serialize(entity, SerializerSettings);
        }
    }
}
