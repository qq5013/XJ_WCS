using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using OpView.View;

namespace OpView
{
    public class FormCollection
    {
        private Dictionary<string, Menu> menus = new Dictionary<string, Menu>();
        private Dictionary<string, Assembly> assemblys = new Dictionary<string, Assembly>();
        public void Add(string tag, Menu menu)
        {
            this.menus.Add(tag, menu);
        }
        public BaseForm GetForm(string tag)
        {
            if (this.menus.ContainsKey(tag))
            {
                try
                {
                    Menu menu = this.menus[tag];
                    Assembly assembly;
                    if (this.assemblys.ContainsKey(menu.AssemblyName))
                    {
                        assembly = this.assemblys[menu.AssemblyName];
                    }
                    else
                    {
                        assembly = Assembly.LoadFrom(menu.AssemblyName);
                        this.assemblys.Add(menu.AssemblyName, assembly);
                    }
                    BaseForm baseForm = (BaseForm)assembly.CreateInstance(menu.ClassName);
                    BaseForm result = baseForm;
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("创建窗体'{0}'失败，原因：{1}", tag, ex.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    BaseForm result = null;
                    return result;
                }
            }
            throw new Exception("未找到指定的窗口，请检查ViewConfig.xml配置文件");
        }
    }
}
