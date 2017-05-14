using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using gamelogic;

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
        public static void ShowWellKnownServiceTypes()

        {

            WellKnownServiceTypeEntry[] entries =

                RemotingConfiguration.GetRegisteredWellKnownServiceTypes();

            foreach (var entry in entries)

            {

                Console.WriteLine("Assembly: {0}", entry.AssemblyName);

                Console.WriteLine("Mode: {0}", entry.Mode);

                Console.WriteLine("URI: {0}", entry.ObjectUri);

                Console.WriteLine("Type: {0}", entry.TypeName);

            }

        }
        static void Main(string[] args)
        {
            //TcpServerChannel channel = new TcpServerChannel(8086);
            //Dictionary<string, string> properties = new Dictionary<string, string>();

            //ChannelServices.RegisterChannel(channel, true);
            //ShowChannelProperties(channel);

            RemotingConfiguration.Configure("server.exe.config", false);
            ShowWellKnownServiceTypes();
            foreach (var i in System.Runtime.Remoting.Channels.ChannelServices.RegisteredChannels)
            {
                ShowChannelProperties((IChannelReceiver)i);
            }
            //RemotingConfiguration.ApplicationName = "Game";
            /*LifetimeServices.LeaseTime = TimeSpan.FromMinutes(10);
            LifetimeServices.RenewOnCallTime = TimeSpan.FromMinutes(3);
            LifetimeServices.SponsorshipTimeout = TimeSpan.FromMinutes(5);

            RemotingConfiguration.RegisterActivatedServiceType(typeof(Hello_1));        
            RemotingConfiguration.RegisterActivatedServiceType(typeof(Hello_2));
            RemotingConfiguration.RegisterActivatedServiceType(typeof(Hello_3));*/

            //RemotingConfiguration.RegisterWellKnownServiceType(typeof(Game), "Game", WellKnownObjectMode.Singleton);

            System.Console.WriteLine("Нажмите Enter для выхода");
            System.Console.ReadLine();
        }
    }
}