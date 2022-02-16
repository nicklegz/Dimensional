namespace user_service.Services
{
    public sealed class FileMessageService : BaseMessageService
    {
        private const string hostName = "rabbitmq";
        private const int port = 5672;
        private const string queueName = "file_service";

        public FileMessageService() : base(hostName, port, queueName)
        {

        }

        public override bool Enqueue(string username)
        {
            
        }
    }
}
