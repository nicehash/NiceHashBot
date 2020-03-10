# NiceHashBot
NHB3 bot for automatic order management.

- [Features](#features)
- [How to run?](#run)
- [How to compile?](#compile)
- [Tips for programmers](#tips)

![](C:\Users\bl4z\source\repos\NHB3\screenshots\00nhb3.png)

# <a name="features"></a> Features

- Run on **test** and **production** environment (instructions on how to obtain API keys https://github.com/nicehash/rest-clients-demo/blob/master/README.md)
- Manage pools (create/edit/delete)
- Manage orders (create/refill/edit/delete)
- Automatically manage orders for **(Bot On mode)**:
    * **price adjustment** - keep price as low as possible (increase and decrease prices)
    * **refilling** - automatically refill order when 90% of available money is consumed
- Console window showing important events, API calls and errors

# <a name="run"></a> Instructions on how to run

- Download binaries from here: https://github.com/nicehash/NiceHashBot/releases
- Extract zip archive
- Run NHB3.exe
- Note: .NET Framework 4.7 or higher is required. You can also run multiple instances of NHB3 - each in own folder with different API credentials.

# <a name="compile"></a> Instructions on how to compile

- Use Visual Studio 2019 or later
- Open project in Visual Studio
- Rebuild & run

# <a name="tips"></a> Tips for programmers

NHB3 is proof of concept (but working) application. It is some how extension of rest-clients-demo (https://github.com/nicehash/rest-clients-demo) and can be used *as is* or upgraded for further improvements in usability and functionality. 
Main purpose is to demonstrate interaction with new NiceHash platform.

NHB3 uses two classes for interaction with NiceHash platform **Api.cs** that prepares all required request headers (authorization - as described here - https://docs.nicehash.com/) and executes remote calls and **ApiConnect.cs** that exposes methods for actions used by NHB3.

Majority of BOT logic is in function **runBot()** inside Home.cs class witch is executed once per minute and then check if order needs some sort of interaction (refill, increase speed or decrease speed).


