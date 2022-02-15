using file_service.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace file_service.Repository;

public class FileRepository : IFileRepository
{
    private readonly IMongoCollection<Models.File> _filesCollection;

    public FileRepository(IOptions<DbSettings> dbSettings)
    {
        var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

        _filesCollection = mongoDatabase.GetCollection<Models.File>(dbSettings.Value.FilesCollectionName);
    }

    public async Task<List<Models.File>> GetListFilesAsync(string username)
    {
        return await _filesCollection.Find(x => x.Username == username).ToListAsync();
    }

    public async Task CreateFileAsync(Models.File file)
    {

    }
}