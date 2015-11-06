using System;
using System.Collections.Generic;
using System.Text;

namespace MCP
{
    public interface IProcessDispatcher
    {
        /// <summary>
        /// ��Service��ĳ��Itemд����
        /// </summary>
        /// <param name="serverName">Service����</param>
        /// <param name="itemName">Item����</param>
        /// <param name="state">Ҫд�������</param>
        bool WriteToService(string serverName, string itemName, object state);

        /// <summary>
        /// ��ȡService��ĳ��Item��״̬
        /// </summary>
        /// <param name="serverName">Service����</param>
        /// <param name="itemName">Item����</param>
        /// <returns>״̬</returns>
        object WriteToService(string serverName, string itemName);

        /// <summary>
        /// ��Processд����
        /// </summary>
        /// <param name="processName">Process����</param>
        /// <param name="itemName">Item����</param>
        /// <param name="state">Ҫд�������</param>
        void WriteToProcess(string processName, string itemName, object state);
    }
}
