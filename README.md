# NiceHashBot
NiceHash bot for automatic order management.

Features:
- Create new orders (including when 2FA is turned on)
- Automatically manage orders for:
    * price adjustment - keep price as low as possible and sustain wanted speed, but keep price below max specified
    * refilling - automatically refill order when it is nearly depleted
    * re-creation - automatically create new order if order is removed by the system (timeout or any other reason)
- Ability to adjust max price and speed limit for each monitored order
- Pool manager to easily define new pools, remove them or use for orders
- Console window showing all important events or errors

Instructions on how to run:
- Download binaries from here: https://github.com/nicehash/NiceHashBot/releases
- Extract zip archive
- Run NiceHashBot.exe
- Note: .NET Framework 2.0 or higher is required. No additional installations are needed if you use Windows 7 or later. Install .NET Framework 2.0 if you use Windows XP or lower.

Instructions on how to compile:
- Use Visual Studio 2010 or later
- Open project in Visual Studio
- Rebuild & run

Tip: You can easily create your own bot software by reusing this code. NiceHashBotLib is the core of everything - modifications of this library should not be needed. Examine NiceHashBot project to see how NiceHashBotLib is used. You can create your own bot with little coding knowledge by just calling certain methods of OrderInstance class such as 'SetMaximalPrice', 'SetLimit' and 'Stop'. With these methods you have full control of what is happening with the order - NiceHashBotLib takes care of evaluating current orders and adjusting lowest possible price.


