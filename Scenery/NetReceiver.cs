using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scenery
{
    public class NetReceiver
    {
        public TcpListener tcpListener;
        public Thread listenThread;
        public UdpClient udpClient;
        public Thread UDPThread;
        int UDPPacketsCounts;
        private BackgroundWorker bkgUDPListener;
        string msg;
        public NetReceiver(int port)
        {
            this.tcpListener = new TcpListener(IPAddress.Any, 0);
            this.udpClient = new UdpClient(port);
            this.UDPThread = new Thread(new ThreadStart(UDPListen));
           // this.listenThread = new Thread(new ThreadStart(ListenForClients));
           // this.listenThread.Start();
            this.UDPThread.Start();
        }
        public void CountUDPPackets()
        {
            UDPPacketsCounts = 0;
        }
        public void Abort()
        {
            UDPThread.Abort();
            udpClient.Close();
            listenThread.Abort();
            tcpListener.Stop();
        }
        public void UDPListen()
        {
            while (true)
            {
                IPEndPoint RemoteIPEndPoint = new IPEndPoint(IPAddress.Any, 0);
                try
                {

                    // Blocks until a message returns on this socket from a remote host.
                    Byte[] receiveBytes = udpClient.Receive(ref RemoteIPEndPoint);

                    string returnData = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine("This is the message you received " +
                                                returnData.ToString());
                    Console.WriteLine("This message was sent from " +
                                                RemoteIPEndPoint.Address.ToString() +
                                                " on their port number " +
                                                RemoteIPEndPoint.Port.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
