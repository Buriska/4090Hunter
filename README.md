# 4090Hunter

Simple bot designed to help the average user beat the scalpers and acquire a 4090FE GPU from Best Buy for their own personal use.

![4090 Hunter Console Window](https://github.com/Buriska/4090Hunter/blob/master/4090Hunter/4090Hunter.png)

## Setup

This application uses [Discord.Net](https://github.com/discord-net/Discord.Net) to notify the user when stock is available. Before you can run the bot, you will need a **Discord Role ID** (for mentions) and **Discord Webhook URL** (where the message should be sent).

You can set these values in the **App.config** file under the **'RoleID'** and **'Webhook'** keys.

``` 
App.config

<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<appSettings>
		<add key="RoleID" value="***ROLE ID HERE***" />
		<add key="Webhook" value="***WEBHOOK URL HERE***" />
	</appSettings>
</configuration>
```

Once these values have been set, run the application and it should begin automatically checking BestBuy.com every few minutes for 4090FE inventory. This bot uses your local ISP and does not make use of any proxies, please refrain from checking the website at a higher frequency as this may lead to a block or ban from BestBuy.com.

## Notification

Once inventory is found, the bot will send a Discord notification similar to the image below:
![Discord Notification](https://github.com/Buriska/4090Hunter/blob/master/4090Hunter/stock_notice.png)

You will need to manually click the link and join the 'queue' on BestBuy.com to purchase the GPU.




**Good luck and happy hunting!**





