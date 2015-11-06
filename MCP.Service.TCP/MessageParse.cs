using System;
using System.Collections.Generic;
using System.Text;
 

namespace MCP.Service.TCP
{
    public class MessageParse : MCP.IProtocolParse
    {
        public Message Parse(string msg)
        {
            Message result = null;
           
            try
            {
                string Comd = msg.Substring(0, 3);
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                dictionary.Add("TaskNo", msg.Substring(3).Replace("\r\n", ""));
                result = new Message(true, msg, Comd, dictionary);
            }
            catch
            {
                result = new Message(msg);
            }
            return result;
        }
    }
}