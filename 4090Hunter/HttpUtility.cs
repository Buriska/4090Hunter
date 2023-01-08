using HtmlAgilityPack;
using System.Net.Http.Headers;

namespace _4090Hunter
{
    public class HttpUtility
    {
        private static Random rand = new();
        private static int runCount;

        public static async Task CheckPage(string url)
        {
            Console.ResetColor();
            var client = new HttpClient();

            client.Timeout = TimeSpan.FromMinutes(5);
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36");
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("br"));
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("* HTTP ***");

            try
            {
                var resp = await client.GetAsync(url);
                var result = resp.Content.ReadAsStringAsync().Result;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"* RESP *** {resp.StatusCode}");
  

                var doc = new HtmlDocument();
                doc.LoadHtml(result);

                var cartButton = doc.DocumentNode.SelectNodes("//button[contains(@class, 'add-to-cart-button')]");

                if (cartButton == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("'Cart' button not found!");
                    return;
                }

                if (cartButton[0].Attributes["data-sku-id"].Value == "6521430")
                {
                    var buttonState = cartButton[0].Attributes["data-button-state"].Value;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"* CART *** {buttonState}");

                    if (buttonState != "SOLD_OUT")
                    {
                        DiscordUtility.SendDiscordMessage(url);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.WriteLine("NOTIFICATION SENT! GOOD LUCK!");
                        Console.ResetColor();
                        Environment.Exit(0);
                    }
                }

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("* DONE ***");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ex.Message}");
            }
            finally
            {
                var wait = rand.Next(1, 3);
                Console.ForegroundColor = ConsoleColor.DarkGray;

                runCount++;
                Console.WriteLine($"CHECKED {runCount} TIMES");
                Console.WriteLine($"NEXT RUN IN {wait} MINUTE(S)");
                Console.WriteLine();

                int statusOffset = 8;
                int topRow = Console.CursorTop;

                for (int a = wait * 60; a >= 0; a--)
                {
                    Console.SetCursorPosition(0, topRow);

                    await Task.Delay(TimeSpan.FromSeconds(1));
                    Console.Write("WAITING FOR {0:00} SECONDS...", a);
                }
            }

            Console.WriteLine();
            Console.Clear();
        }
    }
}
