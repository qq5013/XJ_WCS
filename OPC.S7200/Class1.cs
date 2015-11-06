using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPCSiemensDAAutomation;

namespace OPC.S7200
{
    private static OPCServer OpcSvr = new OPCServerClass();

        //OPC组集
        private static OPCGroups OpcGps;

        //储柜标签组，仅使用一个
        private static OPCGroup OpcGpStorage;
       
        /********************哈希缓存表***************************/
        //哈希表,缓存储柜号与标签组中ID的匹配关系
        private static Hashtable HashCache_storage = Hashtable.Synchronized(new Hashtable());

    class Class1
    {
    }
}
