using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public static class TelegramNotify
{
    private static readonly HttpClient client = new HttpClient();

    private const string BotToken = "Put_Your_Bot_Token_Here";
    private const string GroupChatId = "Put_Your_Group_ID_Here";

    public static void SendLog(string header, string body)
    {
        Task.Run(() => SendAsync(header, body));
    }

    private static async Task SendAsync(string header, string body)
    {
        try
        {
            string message = $"*{header.ToUpper()}*\n\n{body}\n\n_System Notification_";

            var url = $"https://api.telegram.org/bot{BotToken}/sendMessage";

            var payload = new
            {
                chat_id = GroupChatId,
                text = message,
                parse_mode = "Markdown"
            };

            string json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PostAsync(url, content);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Telegram Error: " + ex.Message);
        }
    }
}
