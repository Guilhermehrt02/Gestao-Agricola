using OpenAI.Chat;


namespace Application.Module.IA
{
    public interface IAIProvider
    {
        List<ChatMessage> GeneratePayload(string prompt, Image image);
        Task<string> Request(List<ChatMessage> payload);
    }

    public class IAProvider(IAIProvider client) : IAIProvider
    {
        private readonly IAIProvider _client = client;

        public List<ChatMessage> GeneratePayload(string prompt, Image image)
        {
            return _client.GeneratePayload(prompt, image);
        }

        public async Task<string> Request(List<ChatMessage> payload)
        {
            return await _client.Request(payload);
        }
    }
}
