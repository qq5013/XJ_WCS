using System;
using System.Collections.Generic;
using System.Text;

namespace MCP
{
    public class MCPException: Exception
    {
        public MCPException(string message)
            : base(message)
        {
        }
    }
}
