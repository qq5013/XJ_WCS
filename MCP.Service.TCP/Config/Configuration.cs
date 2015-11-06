using System;
using System.Xml;

namespace MCP.Service.TCP.Config
{
	/// <summary>
	/// OPC�����ļ�������
	/// </summary>
	public class Configuration
	{
		private XmlDocument doc;

		private string ip;

		private int port;

        private string type = "";

        public string Type
        {
            get 
            {
                return type;
            }
        }

		public string IP
		{
			get
			{
				return ip;
			}
            set
            {
                this.ip = value;
            }
		}

		public int Port
		{
			get
			{
				return port;
			}
            set
            {
                this.port = value;
            }
		}
        private string configFile = "";

		public Configuration(string configFile)
		{
            this.configFile = configFile;
			doc = new XmlDocument();
			doc.Load(configFile);
			Initialize();
		}

        public void Save()
        {
            XmlNodeList nodeList = doc.GetElementsByTagName("TCPServer");
            if (nodeList.Count != 0)
            {
                XmlNode xmlNode = nodeList[0];
                xmlNode.Attributes["IP"].Value = ip;
                xmlNode.Attributes["Port"].Value = port.ToString();
                doc.Save(configFile);
            }
            else
            {
                throw new Exception("�������ļ����Ҳ�������UDPServer����Ϣ");
            }
        }

		private void Initialize()
		{
			XmlNodeList nodeList = doc.GetElementsByTagName("TCPServer");
			if (nodeList.Count != 0)
			{
                XmlNode xmlNode = nodeList[0];
                ip = xmlNode.Attributes["IP"].Value.ToString();
                port = int.Parse(xmlNode.Attributes["Port"].Value.ToString());
			}
			else
			{
                throw new Exception("�������ļ����Ҳ�������TCPServer����Ϣ");
			}

            nodeList = doc.GetElementsByTagName("Parse");
            if (nodeList.Count != 0)
            {
                XmlNode xmlNode = nodeList[0];
                type = xmlNode.Attributes["Type"].Value.ToString();
            }
            else
            {
                throw new Exception("�������ļ����Ҳ�������Parse����Ϣ");
            }


		}
	}
}
