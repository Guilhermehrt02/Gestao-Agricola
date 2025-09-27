using OpenAI;
using OpenAI.Chat;

namespace Application.Module.IA
{

    public class GPT : IAIProvider
    {
        private readonly ChatClient client;

        private const string apiKey = "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";

        public GPT()
        {
            client = new(model: "gpt-5", apiKey: apiKey);
        }

        public List<ChatMessage> GeneratePayload(string prompt, Image image)
        {
            // var messages = new List<ChatMessage>
            // {
            //     new SystemChatMessage("Analise as imagens e retorne o resultado conforme as instruções.")
            // };

            // var userContentParts = new List<ChatMessageContentPart>
            // {
            //     ChatMessageContentPart.CreateTextPart(prompt)
            // };

            // var imageUrl = $"data:image/{image.Type};base64,{image.EncodeBase64()}";
            // userContentParts.Add(
            //     ChatMessageContentPart.CreateTextPart(
            //         $"url: {imageUrl}"
            //     )
            // );
            // messages.Add(new UserChatMessage(userContentParts));
            // return messages;

            var messages = new List<ChatMessage>
            {
                new SystemChatMessage("Analise as imagens e retorne o resultado conforme as instruções.")
            };

            var userContentParts = new List<ChatMessageContentPart>
            {
                ChatMessageContentPart.CreateTextPart(prompt),
                ChatMessageContentPart.CreateImagePart(
                    BinaryData.FromBytes(GetBytesFromFormFile(image.ImageBuffer)),
                    image.ImageBuffer.ContentType,
                    imageDetailLevel: "high"
                )
            };

            messages.Add(new UserChatMessage(userContentParts));
            return messages;
        }


        public async Task<string> Request(List<ChatMessage> payload)
        {
            try
            {
                var response = await client.CompleteChatAsync(payload);

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

        private static byte[] GetBytesFromFormFile(Microsoft.AspNetCore.Http.IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}