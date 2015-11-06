using System;
using System.Collections.Generic;
using System.Text;
using MCP;
using System.Data;
using IDAL;

namespace Process
{
    public class StockFinishProcess : AbstractProcess
    {
        protected override void StateChanged(StateItem stateItem, IProcessDispatcher dispatcher)
        {
            try
            {
                Dictionary<string, string> msg = (Dictionary<string, string>)stateItem.State;
                object o = WriteToService("StockPLC", "PLCFree");
                switch (stateItem.ItemName)
                {

                    case "ARQ": //入库申请
                        if (o.ToString() == "1")
                        {
                            //入库写入
                            BLL.BLLBase bll = new BLL.BLLBase();
                            DataTable dtTask = bll.FillDataTable("WCS.SelectTask", new DataParameter[] { new DataParameter("@TaskNo", msg["TaskNo"]) });

                            int TaskType = int.Parse(dtTask.Rows[0]["TaskType"].ToString());
                            string TaskNo = msg["TaskNo"];
                            string CellCode = dtTask.Rows[0]["CellCode"].ToString();

                            //写入任务号
                            WriteToService("StockPLC", "TaskNo1", int.Parse(TaskNo.Substring(0, 4)));
                            WriteToService("StockPLC", "TaskNo2", int.Parse(TaskNo.Substring(4, 4)));
                            WriteToService("StockPLC", "TaskNo3", int.Parse(TaskNo.Substring(8)));
                            //写入起始位，结束位
                            if (TaskType == 3)
                            {
                                WriteToService("StockPLC", "FromStation1", 0);
                                WriteToService("StockPLC", "FromStation2", 0);
                                WriteToService("StockPLC", "FromStation3", 0);
                            }
                            else
                            {
                                WriteToService("StockPLC", "FromStation1", int.Parse(CellCode.Substring(0, 3)));
                                WriteToService("StockPLC", "FromStation2", int.Parse(CellCode.Substring(0, 3)));
                                WriteToService("StockPLC", "FromStation3", 68);
                            }

                            WriteToService("StockPLC", "ToStation1", int.Parse(CellCode.Substring(0, 3)));
                            WriteToService("StockPLC", "ToStation2", int.Parse(CellCode.Substring(3, 3)));
                            WriteToService("StockPLC", "ToStation3", int.Parse(CellCode.Substring(6)));
                            //写入标识
                            WriteToService("StockPLC", "WriteFinished", 1);

                            WriteToService("PDATcp", "msg", "1");
                        }
                        else
                        {
                            WriteToService("PDATcp", "msg", "0");
                        }
                        break;


                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
