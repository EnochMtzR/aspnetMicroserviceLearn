namespace Catalog.API.Models
{
    public class DatabaseSettings
    {
        public static string section = "DatabaseSettings";

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }
    }
}