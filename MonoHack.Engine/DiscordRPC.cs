using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoHack.Engine
{
    public class DiscordRPC
    {
        ///
        /// Abstraction layer for our Discord RPC Library
        ///

        public DiscordRpcClient client;

        //Called when your application first starts.
        //For example, just before your main loop, on OnEnable for unity.
        public void Initialize()
        {
            /*
            Create a discord client
            NOTE: 	If you are using Unity3D, you must use the full constructor and define
                     the pipe connection.
            */
            client = new DiscordRpcClient("529725485635338240");

            //Set the logger
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            //Subscribe to events
            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Received Update! {0}", e.Presence);
            };

            //Connect to the RPC
            client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(new RichPresence()
            {
                Details = "MonoHack Demo",
                State = "Debugging",
                Assets = new Assets()
                {
                    LargeImageKey = "monohack_512x",
                    LargeImageText = "MonoHack",
                    SmallImageKey = "debug",
                    SmallImageText = "Debugging"
                }
            });
        }

    }
}
