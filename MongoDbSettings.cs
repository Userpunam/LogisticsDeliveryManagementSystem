namespace LogisticsDeliveryManagementSystem.Configurations
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string PackageCollection { get; set; } = string.Empty;
        public string DriverCollection { get; set; } = string.Empty;
        public string RouteCollection { get; set; } = string.Empty;
    }

}
