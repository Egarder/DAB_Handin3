namespace BirthClinicMongoDB
{
    public interface IMongoDbSettings
    {
        static string DatabaseName { get; set; }
        static string ConnectionString { get; set; }
    }
}
