using System;
using System.Collections.Generic;
using System.Text;

namespace MCP
{
    public enum ProcessState {Uninitialize, Initialized, Released, Stared, Stoped, Suspend, Waiting, Processing};
    public interface IProcess
    {
        String Name
        {
            get;
            set;
        }

        ProcessState State
        {
            get;
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        void Initialize(Context context);

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
        /// ������
        /// </summary>
        void Suspend();

        /// <summary>
        /// ��ʼ����Ĵ���
        /// </summary>
        void Resume();

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="stateItem">��Ҫ�����״̬</param>
        void Process(StateItem stateItem);
    }
}
