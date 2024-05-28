namespace BooksApp.Commons.Helpers.Serialization.Json
{
    public static class SerializationExtensions
    {
        public static string ToJson<T>(this T source)
        {
            return new SerializationsHelper().Serialize(source);
        }

        public static string ToJson<T>(this T source, bool useFormating)
        {
            return new SerializationsHelper(useFormating).Serialize(source);
        }
    }
}
