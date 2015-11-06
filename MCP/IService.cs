using System;
using System.Collections.Generic;
using System.Text;

namespace MCP
{
    public class StateChangedArgs
    {
        private string name;
        private string itemName;
        private object state;

        public string Name
        {
            get { return name; }
        }

        public string ItemName
        {
            get { return itemName; }
        }

        public object State
        {
            get { return state; }
        }

        public StateChangedArgs(string name, string itemName, object state)
        {
            this.name = name;
            this.itemName = itemName;
            this.state = state;
        }
    }
    public delegate void StateChangedEventHandler(object sender, StateChangedArgs e);

    public interface IService
    {
        event StateChangedEventHandler OnStateChanged;

        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        void Initialize(string fileName);

        /// <summary>
        /// �ͷ���Դ
        /// </summary>
        void Release();

        /// <summary>
        /// ��ʼ����
        /// </summary>
        void Start();

        /// <summary>
        /// ֹͣ����
        /// </summary>
        void Stop();

        /// <summary>
        /// ��ȡ���״̬
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        object Read(string itemName);

        /// <summary>
        /// �������״̬
        /// </summary>
        /// <param name="itemName">������</param>
        /// <param name="state">״̬</param>
        /// <returns>����״̬�Ƿ�ɹ�</returns>
        bool Write(string itemName, object state);

        /// <summary>
        /// ģ���������
        /// </summary>
        /// <param name="itemName">������</param>
        /// <param name="state">״̬</param>
        void Invoke(string itemName, object state);
    }
}
