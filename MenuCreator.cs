using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Metadata
{
    internal class MenuCreator
    {
        public Menu Menu { get; set; }

        public MenuCreator(string filename = "menu.txt") {
            string[] menuData = Reader.Read();
             
            Menu = new Menu();
            MenuItem header, header0 = new MenuItem();

            for (int i = 0; i < menuData.Length; i++)
            {
                string[] item = menuData[i].Split(' ');

                header = new MenuItem();
                header.Header = item[1]; 
                switch (item[2])
                {
                     case "1":
                         header.IsEnabled = false; break;                          
                     case "2":
                         header.Visibility = Visibility.Collapsed; break;
                     default: break;
                }
                if (item.Length == 4 && item[3] != "")
                {
                    header.Click += (sender, e) => { Console.WriteLine("Вызван метод " + item[3]); };
                }

                if (item[0] == "0")
                {
                    Menu.Items.Add(header);
                    header0 = header;
                }
                else
                {
                    MenuItem h = header0;
                    for (int j = 0; j < Convert.ToInt32(item[0])-1; j++)
                    {
                        h = (MenuItem)h.Items[h.Items.Count - 1];
                    }
                    h.Items.Add(header);
                }
            }
        }

        static private void FindInMenu(string name, int status, ItemCollection items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (((MenuItem)items[i]).Header.Equals(name))
                {
                    if (status == 1)
                    {
                        ((MenuItem)items[i]).IsEnabled = false;
                    }
                    else
                    {
                        ((MenuItem)items[i]).Visibility = Visibility.Collapsed;
                    }
                    return;
                }
                FindInMenu(name, status, ((MenuItem)items[i]).Items);
            }
            
        }

        public void EditForUser(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                string[] item = data[i].Split(' ');
                if (item[1] != "0")
                {
                    FindInMenu(item[0], Convert.ToInt32(item[1]), Menu.Items);
                }
            }
        }
    }
}
