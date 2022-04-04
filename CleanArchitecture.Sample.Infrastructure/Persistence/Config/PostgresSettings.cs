namespace CleanArchitecture.Sample.Infrastructure.Persistence.Config
{
    public class PostgresSettings
    {
        public static string SectionName = "PostgresSettings";
        public string ConnectionString { get; set; }
    }
}