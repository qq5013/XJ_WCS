using System;
using System.Collections.Generic;
using System.Text;

namespace MCP
{
    public sealed class DefaultDispatcher: IServiceDispatcher, IProcessDispatcher
    {
        public bool WriteToService(string serverName, string itemName, object state)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("[дService] [{0} {1} {2}]", serverName, itemName, state));
            return true;
        }

        public object WriteToService(string serverName, string itemName)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("[��Service] [{0} {1}]", serverName, itemName));
            return -1;
        }

        public void WriteToProcess(string processName, string itemName, object state)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("[дProcess] [{0} {1} {2}]", processName, itemName, state));
        }

        public void DispatchState(StateItem item)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("[����״̬] [{0} {1} {2}]", item.Name, item.ItemName, item.State));
        }
    }
}
