using OpenAI;
using OpenAI.Chat;

namespace Application.Module.IA
{
    public interface IGPT
    {
        Task<string> Request(List<ChatMessage> payload);
        List<ChatMessage> GeneratePayload(string prompt, List<Image> images);
    }

    public class GPT : IGPT
    {
        private readonly OpenAIClient client;

        public GPT()
        {
            client = new OpenAIClient("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");
        }

        public List<ChatMessage> GeneratePayload(string prompt, List<Image> images)
        {
            var messages = new List<ChatMessage>
            {
                new SystemChatMessage("Analise as imagens e retorne o resultado conforme as instruções.")
            };

            var userContentParts = new List<ChatMessageContentPart>
            {
                ChatMessageContentPart.CreateTextPart(prompt)
            };

            // Adiciona imagens se fornecidas
            if (images != null && images.Count > 0)
            {
                foreach (var image in images)
                {
                    var imageUrl = $"data:image/{image.Type};base64,{image.EncodeBase64(image.Data)}";
                    userContentParts.Add(
                        ChatMessageContentPart.CreateTextPart(
                            $"url: {imageUrl}"
                        )
                    );
                }
            }

            messages.Add(new UserChatMessage(userContentParts));
            return messages;
        }

        public async Task<string> Request(List<ChatMessage> payload)
        {
            try
            {
                var chatClient = client.GetChatClient("gpt-5");

                var response = await chatClient.CompleteChatAsync(payload);

                if (response?.Value?.Content?.Count > 0)
                {
                    return response.Value.Content[0].Text;
                }

                return "Nenhuma resposta obtida.";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao fazer a requisição: " + ex.Message, ex);
            }
        }
    }
}