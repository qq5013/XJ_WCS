using System;
using System.Collections.Generic;
using System.Text;

namespace MCP
{
    public interface IDeviceManager
    {
        Resource GetResource(string deviceClass, string stateCode);

        Dictionary<string, List<Device>> GetDevice();
    }
}
