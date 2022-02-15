namespace file_service.Repository
{
    public interface IFileRepository
    {
        public Task<List<Models.File>> GetListFilesAsync(string username);
        public Task CreateFileAsync(Models.File file);
    }
}
