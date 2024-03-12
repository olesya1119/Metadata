using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metadata
{
    internal static class Reader
    {
        /// <summary>
        /// Читает данные с файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns></returns>
        public static string[] Read(string path = "../../res/menu.txt")
        {
            string[] strings = new string[1];
            string line;
            try
            {
                StreamReader sr = new StreamReader(path);
                line = sr.ReadLine();
                while (line != null)
                {
                    Array.Resize(ref strings, strings.Length + 1);
                    strings[strings.Length - 2] = line;
                    line = sr.ReadLine();
                }
                Array.Resize(ref strings, strings.Length - 1);
                sr.Close();
                return strings;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Возвращает данные о пользователе по логину и паролю
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="pass">Пароль пользователя</param>
        /// <param name="path">Путь к файлу с данными о пользователях</param>
        /// <returns></returns>
        public static string[] ReadUserData(string login, string pass, string path = "../../res/users.txt")
        {
            string[] strings = Read(path);
            try
            {
                for (int i = 0; i < strings.Length; i++)
                {
                    if (strings[i].StartsWith("#"))
                    {
                        string[] strgs = strings[i].Split(' ');
                        if (strgs[0].Substring(1) == login && strgs[1] == pass)
                        {
                            int j = i + 1;
                            string[] userData = new string[1];
                            while (j < strings.Length && !strings[j].StartsWith("#"))
                            {
                                Array.Resize(ref userData, userData.Length + 1);
                                userData[userData.Length - 2] = strings[j];
                                j++;
                            }
                            Array.Resize(ref userData, userData.Length - 1);
                            return userData;
                        }
                    }
                }
            }
            catch (Exception e) { throw e; }
            return null;
        }
    }
}
