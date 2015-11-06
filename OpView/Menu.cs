using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpView
{
    public class Menu
    {
        private string name;
        private string className;
        private string assemblyName;
        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public string ClassName
        {
            get
            {
                return this.className;
            }
        }
        public string AssemblyName
        {
            get
            {
                return this.assemblyName;
            }
        }
        public Menu(string name, string type)
        {
            this.name = name;
            string[] array = type.Split(new char[]
			{
				','
			});
            if (array.Length >= 2)
            {
                this.className = array[0].Trim();
                this.assemblyName = array[1].Trim();
                return;
            }
            throw new Exception("Menu配置项不正确，请检查配置文件。");
        }
    }
}
