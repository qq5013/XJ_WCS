using System;
using System.Collections.Generic;
using System.Text;
using MCP.Collection;
using MCP.View;

namespace MCP
{
    public sealed class Context
    {
        private AttributeCollection attributes = new AttributeCollection();
        
        private ServiceCollection services = new ServiceCollection();

        private ProcessCollection processes = new ProcessCollection();

        private RelationCollection relations = new RelationCollection();

        private IServiceDispatcher serviceDispatcher = null;

        private IProcessDispatcher processDispatcher = null;

        private IDeviceManager deviceManager = null;

        private string viewProcess = "ViewProcess";

        public event EventHandler OnPostInitialize = null;

        /// <summary>
        /// ���Լ���
        /// </summary>
        public AttributeCollection Attributes
        {
            get { return attributes; }
        }

        /// <summary>
        /// ���񼯺�
        /// </summary>
        public ServiceCollection Services
        {
            get { return services; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public ProcessCollection Processes
        {
            get { return processes; }
        }

        /// <summary>
        /// ��ϵ����
        /// </summary>
        public RelationCollection Relation
        {
            get { return relations; }
        }

        public IProcessDispatcher ProcessDispatcher
        {
            get { return processDispatcher; }
            set { processDispatcher = value; }
        }

        public IDeviceManager DeviceManager
        {
            get { return deviceManager; }
            set { deviceManager = value; }
        }

        public string ViewProcess
        {
            get { return viewProcess; }
            set { viewProcess = value; }
        }

        public Context()
        {
            Dispatcher dispatcher = new Dispatcher(this);
            processDispatcher = dispatcher;
            serviceDispatcher = dispatcher;

            deviceManager = new DeviceManager();
        }

        public void Release()
        {
            processDispatcher = null;
            serviceDispatcher = null;
            deviceManager = null;
            processes = null;
            services = null;
        }

        /// <summary>
        /// ע��Service
        /// </summary>
        /// <param name="service"></param>
        public void RegisterService(IService service)
        {
            service.OnStateChanged += new StateChangedEventHandler(service_OnStateChanged);
            services.Add(service);
        }

        void service_OnStateChanged(object sender, StateChangedArgs e)
        {
            serviceDispatcher.DispatchState(new StateItem(e.Name, e.ItemName, e.State));
        }

        /// <summary>
        /// ע�ᴦ��Item��Process
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="itemName"></param>
        /// <param name="process"></param>
        public void RegisterRelation(string serviceName, string itemName, IProcess process)
        {
            processes.Add(process);

            if (serviceName != null || serviceName.Trim().Length != 0)
                relations.Add(serviceName, itemName, process.Name);
        }

        /// <summary>
        /// ע���Serviceû����ϵ��Process
        /// </summary>
        /// <param name="process"></param>
        public void RegisterProcess(IProcess process)
        {
            processes.Add(process);
        }

        /// <summary>
        /// ע�������ʾProcess
        /// </summary>
        /// <param name="processControl"></param>
        public void RegisterProcessControl(ProcessControl processControl)
        {
            processControl.Initialize(this);
            processes.Add(processControl);
        }

        internal void CompleteInitialize()
        {
            if (OnPostInitialize != null)
                OnPostInitialize(this, new EventArgs());
        }
    }
}
