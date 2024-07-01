using WebUI.Manager;

namespace WebUI.Handlers
{
    public class ChatHandler : WebSocketHandler
    {
        public ChatHandler(ConnectionManager connectionManager) : base(connectionManager)
        {
        }
    }
}
