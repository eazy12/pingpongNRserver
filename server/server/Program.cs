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
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data Source=C:\Users\WorstOne\Source\Repos\pingpongNRserver2\server\server\db1.accdb;" +
        @"User Id=;Password=;";
            OleDbConnection connection = new OleDbConnection(connectionString);

            string queryString = "INSERT INTO data (player1, player2, score1, score2, play_date) VALUES ('sda', 'asdasd', '1', '2', '10:00:00' )";

            OleDbCommand command = new OleDbCommand(queryString, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            RemotingConfiguration.Configure("server.exe.config", false);
            foreach (var i in ChannelServices.RegisteredChannels)
            {
                ShowChannelProperties((IChannelReceiver)i);
            }

            Console.ReadLine();
        }
    }
}