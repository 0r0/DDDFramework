namespace DDDFramework.Infrastructure.Config.SettingModels;

public class MongoDbSettings
{
    public string? Url { get; set; }
    public string? DatabaseName { get; set; }
    public string? CollectionName { get; set; }
    public string? Type { get; set; } 
    public string? UserName { get; set; }
    public string? Password { get; set; }
}