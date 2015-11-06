using System;
using System.Collections.Generic;
using System.Text;

namespace MCP
{
    public interface IProtocolParse
    {
        Message Parse(string msg);
    }
}
