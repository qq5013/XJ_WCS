using System;
using System.Collections.Generic;
using System.Xml;
namespace OpView
{
    public class Config
    {
        private List<MenuList> menuList;
        private bool captionVisible = true;
        private bool titleVisible = true;
        private int menuWidth = 180;
        private bool minBox = true;
        private bool maxBox = true;
        private int itemHeight = 20;
        private string title;
        public List<MenuList> MenuList
        {
            get
            {
                return this.menuList;
            }
        }
        public bool CaptionVisible
        {
            get
            {
                return this.captionVisible;
            }
        }
        public bool TitleVisible
        {
            get
            {
                return this.titleVisible;
            }
        }
        public int MenuWidth
        {
            get
            {
                return this.menuWidth;
            }
        }
        public bool MinBox
        {
            get
            {
                return this.minBox;
            }
        }
        public bool MaxBox
        {
            get
            {
                return this.maxBox;
            }
        }
        public int ItemHeight
        {
            get
            {
                return this.itemHeight;
            }
        }
        public string Title
        {
            get
            {
                return this.title;
            }
        }
        public Config()
        {
            this.menuList = new List<MenuList>();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("ViewConfig.xml");
            XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("Menus");
            foreach (XmlNode xmlNode in elementsByTagName)
            {
                string innerText = xmlNode.Attributes["Name"].InnerText;
                List<Menu> list = new List<Menu>();
                foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
                {
                    Menu item = new Menu(xmlNode2.Attributes["Name"].InnerText, xmlNode2.Attributes["Type"].InnerText);
                    list.Add(item);
                }
                this.MenuList.Add(new MenuList(innerText, list));
            }
            XmlNodeList elementsByTagName2 = xmlDocument.GetElementsByTagName("Caption");
            if (elementsByTagName2.Count != 0)
            {
                this.minBox = elementsByTagName2[0].Attributes["MinBox"].InnerText.ToString().ToUpper().Equals("TRUE");
                this.maxBox = elementsByTagName2[0].Attributes["MaxBox"].InnerText.ToString().ToUpper().Equals("TRUE");
            }
            XmlNodeList elementsByTagName3 = xmlDocument.GetElementsByTagName("Title");
            if (elementsByTagName3.Count != 0)
            {
                this.titleVisible = elementsByTagName3[0].Attributes["Visible"].InnerText.ToString().ToUpper().Equals("TRUE");
                this.title = elementsByTagName3[0].Attributes["Text"].InnerText;
            }
            XmlNodeList elementsByTagName4 = xmlDocument.GetElementsByTagName("MenuBar");
            if (elementsByTagName4.Count != 0)
            {
                this.menuWidth = Convert.ToInt32(elementsByTagName4[0].Attributes["Width"].InnerText);
            }
            XmlNodeList elementsByTagName5 = xmlDocument.GetElementsByTagName("MenuItem");
            if (elementsByTagName5.Count != 0)
            {
                this.itemHeight = Convert.ToInt32(elementsByTagName5[0].Attributes["Height"].InnerText);
            }
        }
    }
}
