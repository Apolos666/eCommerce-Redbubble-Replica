namespace api.Configurations;

public class DatabaseConfig
{
    public string ConnectionString { get; set; }
    public bool DetailedErrors { get; set; }
    public bool SensitiveDataLogging { get; set; }
}