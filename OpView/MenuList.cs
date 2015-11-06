using System;
using System.Collections.Generic;

namespace OpView
{
    public class MenuList
    {
        private string name;
        private List<Menu> menus;
        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public List<Menu> Menus
        {
            get
            {
                return this.menus;
            }
        }
        public MenuList(string name, List<Menu> menus)
        {
            this.name = name;
            this.menus = menus;
        }
    }
}
