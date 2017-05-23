using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Data.OleDb;

namespace server
{
    class Program
    {
        static void ShowChannelProperties(IChannelReceiver channel)
        {
            Console.WriteLine("Name: " + channel.ChannelName);
            Console.WriteLine("Priority: " + channel.ChannelPriority);

            ChannelDataStore data = (ChannelDataStore)channel.ChannelData;
            if (data != null)
            {
                foreach (string uri in data.ChannelUris)
                {
                    Console.WriteLine("URI: " + uri);
                }
            }
        }
        
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("server.exe.config", false);
            foreach (var i in ChannelServices.RegisteredChannels)
            {
                ShowChannelProperties((IChannelReceiver)i);
            }

            Console.ReadLine();
        }
    }
}