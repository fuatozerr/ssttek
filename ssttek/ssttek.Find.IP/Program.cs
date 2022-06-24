using System;
using System.Net;

namespace ssttek.Find.IP
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
                string hostName = Dns.GetHostName();
                Console.WriteLine("Host Name = " + hostName);
                IPHostEntry local = Dns.GetHostByName(hostName);
                foreach (IPAddress ipaddress in local.AddressList)
                {
                    Console.WriteLine("IPAddress = " + ipaddress.ToString());
                }
            
        }
    }
}
