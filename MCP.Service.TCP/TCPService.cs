﻿using System;
using System.Collections.Generic;
using System.Text;
using MCP;
using TCP;
using System.Net.Sockets;
using System.Net;

namespace MCP.Service.TCP
{
    public class TCPService:MCP.AbstractService 
    {
        
        private DateTime dtTime;
        private Server server = null;
        private Client client = null;
        private string ip = "127.0.0.1";
        private int port = 6000;
        private IProtocolParse protocol = null;
        

        public override void Initialize(string file)
        {
            Config.Configuration config = new Config.Configuration(file);
            protocol = (IProtocolParse)ObjectFactory.CreateInstance(config.Type);

            ip = config.IP;
            port = config.Port;
            server = new Server();
            server.OnReceive += new ReceiveEventHandler(server_OnReceive);
        }
        
        private void server_OnReceive(object sender, ReceiveEventArgs e)
        {
            Message message = null;
            if (null != protocol)
                message = protocol.Parse(e.Read());
            else
            {
                message = new Message(e.Read());
            }
            string text = string.Format("recv: <--- {0}", e.Read());
            WriteToLog(text);

            if (message.Parsed)
                DispatchState(message.Command, message.Parameters);
            dtTime = DateTime.Now;
            
        }        

        public override void Release()
        {            
            server.StopListen();
        }

        public override void Start()
        {            
            server.StartListen(ip, port);
        }

        public override void Stop()
        {
            server.StopListen();
        }

        public override object Read(string itemName)
        {
            throw new Exception("TCPService未实现Read方法，请用System.Net.Sockets.TCPClient类发送TCP消息。");
        }

        public override bool Write(string itemName, object state)
        {
            string text = string.Format("send: ---> {0}", (string)state);
            WriteToLog(text);


            server.Write(ip + ":" + port.ToString(), (string)state);
            return true;
        }

        private void WriteToLog(string Message)
        {
            if (!System.IO.Directory.Exists("PDATcp"))
                System.IO.Directory.CreateDirectory("PDATcp");
            string path = "PDATcp/" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            System.IO.File.AppendAllText(path, string.Format("{0} :  {1}", DateTime.Now, Message + "\r\n"));
        }
    }
}
