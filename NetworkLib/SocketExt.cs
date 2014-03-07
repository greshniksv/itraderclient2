using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Sockets;

namespace NetworkLib
{
    public static class SocketExt
    {
        public delegate void NotifyProgressHandler(int percent);

        public static int SendData(Socket s, byte[] data)
        {
            int total = 0;
            int size = data.Length;
            int dataleft = size;
            int sent;
            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(size);
            sent = s.Send(datasize);
            while (total < size)
            {
                sent = s.Send(data, total, dataleft, SocketFlags.None);
                total += sent;
                dataleft -= sent;
            }
            return total;
        }

        public static byte[] ReceiveData(Socket s)
        {
            int total = 0;
            int recv;
            byte[] datasize = new byte[4];
            recv = s.Receive(datasize, 0, 4, 0);
            int size = BitConverter.ToInt32(datasize, 0);
            int dataleft = size;
            byte[] data = new byte[size];
            while (total < size)
            {
                recv = s.Receive(data, total, dataleft, 0);
                if (recv == 0)
                {
                    data = Encoding.ASCII.GetBytes("exit ");
                    break;
                }
                total += recv;
                dataleft -= recv;
            }
            return data;
        }

        public static void SendFileOld(string filePath, Socket s)
        {
            SendFileOld(filePath, s, 1024 * 8);
        }

        public static void SendFileOld(string filePath, Socket s, int bufSize)
        {
            byte[] data = new byte[bufSize];
            BinaryReader br = new BinaryReader(File.Open(filePath, FileMode.Open));
            long size = br.BaseStream.Length;
            byte[] datasize = new byte[8];
            datasize = BitConverter.GetBytes(br.BaseStream.Length);
            SocketExt.SendData(s, datasize);
            int totalSent = 0;
            int fSent = 0;
            long leftToSend = size;

            while (totalSent < size)
            {
                // Data left is less than buffer. Sending the rest of data
                if (leftToSend < bufSize)
                {
                    data = new byte[leftToSend];
                    br.Read(data, 0, (int)leftToSend);
                }
                else
                {
                    data = new byte[bufSize];
                    br.Read(data, 0, bufSize);
                }
                fSent = SocketExt.SendData(s, data);
                totalSent += fSent;
                leftToSend -= fSent;
            }
            br.Close();
        }

        public static void SendFile(string filePath, Socket s)
        {
            SendFile(filePath, s, 1024 * 8);
        }

        public static void SendFile(string filePath, Socket s, int bufSize)
        {
            byte[] data = new byte[bufSize];
            BinaryReader br = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read));
            long size = br.BaseStream.Length;
            byte[] datasize = new byte[8];
            datasize = BitConverter.GetBytes(br.BaseStream.Length);
            s.Send(datasize);
            int totalSent = 0;
            int fSent = 0;
            long leftToSend = size;

            while (totalSent < size)
            {
                // Data left is less than buffer. Sending the rest of data
                int sizeForSent = 0;
                if (leftToSend < bufSize)
                {
                    sizeForSent = (int)leftToSend;
                    data = new byte[leftToSend];
                    br.Read(data, 0, (int)leftToSend);
                }
                else
                {
                    sizeForSent = bufSize;
                    data = new byte[bufSize];
                    br.Read(data, 0, bufSize);
                }
                fSent = s.Send(data, 0, sizeForSent, SocketFlags.None);
                totalSent += fSent;
                leftToSend -= fSent;
            }
            br.Close();
        }

        public static void RecieveFileOld(string filePath, Socket s, NotifyProgressHandler npHandler)
        {
            RecieveFileOld(filePath, s, npHandler, 1024 * 8);
        }

        public static void RecieveFileOld(string filePath, Socket s, NotifyProgressHandler npHandler, int bufSize)
        {
            byte[] data = new byte[bufSize];
            BinaryWriter bwr = new BinaryWriter(File.Open(filePath, FileMode.Create));
            byte[] datasize = new byte[8];
            datasize = SocketExt.ReceiveData(s);
            long size = BitConverter.ToInt64(datasize, 0);
            int percent = 0;
            int percentPrev = 0;
            long recived = 0;
            while (recived < size)
            {
                data = SocketExt.ReceiveData(s);
                bwr.Write(data, 0, data.Length);
                recived += data.Length;
                percentPrev = percent;
                percent = (int)(recived * 100 / size);
                if (percent > percentPrev)
                {
                    npHandler(percent);
                }
            }
            bwr.Close();
        }

        public static void RecieveFile(string filePath, Socket s, NotifyProgressHandler npHandler)
        {
            RecieveFile(filePath, s, npHandler, 1024 * 8);
        }

        public static void RecieveFile(string filePath, Socket s, NotifyProgressHandler npHandler, int bufSize)
        {
            byte[] data = new byte[bufSize];
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            BinaryWriter bwr = new BinaryWriter(File.Open(filePath, FileMode.Create, FileAccess.Write, FileShare.Write));
            byte[] datasize = new byte[8];
            int recv = s.Receive(datasize);
            long size = BitConverter.ToInt64(datasize, 0);
            int percent = 0;
            int percentPrev = 0;
            long recived = 0;
            int sendedPercent = 0;
            int chunkLeftToRecieve = 0;
            while (recived < size)
            {
                if (size - recived < bufSize)
                {
                    chunkLeftToRecieve = (int)(size - recived);
                    recv = s.Receive(data, 0, chunkLeftToRecieve, SocketFlags.None);
                }
                else
                    recv = s.Receive(data);
                bwr.Write(data, 0, recv);
                recived += recv;
                if (npHandler != null)
                {
                    percentPrev = percent;
                    percent = (int)(recived * 100 / size);
                    if (((percent / 20) >= 1) && ((percent / 20) > sendedPercent))
                    {
                        sendedPercent = percent / 20;
                        npHandler(percent);
                    }
                }
            }
            bwr.Close();
        }
    }
}
