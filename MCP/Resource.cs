using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MCP
{
    public class Resource
    {
        private string deviceClass;

        private string stateCode;

        private string stateDesc;

        private Image image;

        /// <summary>
        /// �豸���
        /// </summary>
        public string DeviceClass
        {
            get { return deviceClass; }
            set { deviceClass = value; }
        }

        /// <summary>
        /// ״̬����
        /// </summary>
        public string StateCode
        {
            get { return stateCode; }
            set { stateCode = value; }
        }

        /// <summary>
        /// ״̬����
        /// </summary>
        public string StateDesc
        {
            get { return stateDesc; }
            set { stateDesc = value; }
        }

        /// <summary>
        /// ״̬ͼƬ
        /// </summary>
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }
    }
}
