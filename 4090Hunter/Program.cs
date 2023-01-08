using _4090Hunter;

Console.Title = "4 0 9 0 | H U N T E R";

if (DiscordUtility.ConfigMissing()) Environment.Exit(0);

string title = @"
   __ __   ____   ____   ____     __  __ __  __ _   __ ______ ______ ____     
  / // /  / __ \ / __ \ / __ \   / / / // / / // | / //_  __// ____// __ \    
 / // /_ / / / // /_/ // / / /  / /_/ // / / //  |/ /  / /  / __/  / /_/ /    
/__  __// /_/ / \__, // /_/ /  / __  // /_/ // /|  /  / /  / /___ / _, _/     
  /_/   \____/ /____/ \____/  /_/ /_/ \____//_/ |_/  /_/  /_____//_/ |_|      
                                                                           ";


bool keepRunning = true;

while (keepRunning)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(title);
    Console.WriteLine(Environment.NewLine);
    Console.ResetColor();

    await HttpUtility.CheckPage("https://www.bestbuy.com/site/nvidia-geforce-rtx-4090-24gb-gddr6x-graphics-card-titanium-and-black/6521430.p?skuId=6521430");
}

