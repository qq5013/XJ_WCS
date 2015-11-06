using System;
using System.Collections.Generic;
using System.Text;

namespace MCP
{
    public interface IServiceDispatcher
    {
        void DispatchState(StateItem item);
    }
}
