using static user_service.Services.BaseMessageService;

namespace user_service.Services
{
    public interface IMessageService
    {
        bool Enqueue(string messageString, MessageType messageType);
    }
}
