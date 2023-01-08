using Discord.Webhook;
using System.Configuration;

namespace _4090Hunter
{
    public class DiscordUtility
    {
        private static readonly string RoleId = ConfigurationManager.AppSettings.Get("RoleID");
        private static readonly string Webhook = ConfigurationManager.AppSettings.Get("Webhook");

        public static async void SendDiscordMessage(string url)
        {
            if (!string.IsNullOrWhiteSpace(Webhook))
            {
                using var client = new DiscordWebhookClient(Webhook);
                await client.SendMessageAsync($"<@&{RoleId}>" + Environment.NewLine + url);
            }

            Console.WriteLine("Discord notification sent!");
        }

        public static bool ConfigMissing()
        {
            var configMissing = false;

            Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrWhiteSpace(RoleId))
            {
                Console.WriteLine("Role ID is null! Please set 'RoleID' first in the app.config file.");
                configMissing = true;
            }

            if (string.IsNullOrWhiteSpace(Webhook))
            {
                Console.WriteLine("Webhook is null! Please set 'Webhook' first in the app.config file.");
                configMissing = true;
            }

            Console.ResetColor();
            return configMissing;
        }
    }
}
