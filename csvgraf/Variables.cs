using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvgraf
{
    public class Variables
    {
        private static string filePath = "";

        public static string FilePath
        {
            get { return filePath; }
            set { filePath = value; }

        }
        private static string Key = "A";

        public static string key
        {
            get { return Key; }
            set { Key = value; }

        }
        public static Form2 F2 = new Form2();
        /*public Options opt = new Options();
        public Form2 f2 = new Form2();*/
        //public Form2 f2 = new Form2();
        public Variables()
        {
            Console.WriteLine("Options class is working!");
        }

        public static string[] getOptions()
        {
            string[] settings = new string[2];
            settings[0] = FilePath;
            settings[1] = key;
            return settings;
        }
        public static void setOptions(string[] values)
        {
            filePath = values[0];
            key = values[1];
            Console.WriteLine(values[1]);
        }
        public void setOptions(string[] option, string[] values)
        {
            for (int i = 0; i < option.Length; i++)
            {
                switch (option[i])
                {
                    case "file":
                        FilePath = values[i];
                        break;
                    case "key":
                        key = values[i];
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
