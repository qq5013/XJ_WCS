using System;
using System.Collections.Generic;
using System.Text;

namespace MCP.Config
{
    public class ProcessItemConfig
    {
        private string serviceName;
        private string itemName;

        public string ServiceName
        {
            get { return serviceName; }
        }

        public string ItemName
        {
            get { return itemName; }
        }

        public ProcessItemConfig(string serviceName, string itemName)
        {
            this.serviceName = serviceName;
            this.itemName = itemName;
        }
    }
}
