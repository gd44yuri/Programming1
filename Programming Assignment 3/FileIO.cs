using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class FileIO
    {

        public List<string> strings = new List<string>();

        string winDir = Environment.CurrentDirectory;

        public void Read(String _name)
        {
            StreamReader reader = new StreamReader(winDir + "\\" + _name + ".txt");
            try
            {
                while (reader.Peek() != -1)
                {
                    strings.Add(reader.ReadLine());
                }
            }
            catch
            {
                strings.Add("There is nothing in this file.");
            }
            finally
            {
                reader.Close();
            }

            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }
        }

        public void Write(String _name, List<string> _strings)
        {

            StreamWriter writer = new StreamWriter(winDir + "\\" + _name + ".txt");

            foreach (string str in _strings) {

                writer.WriteLine(str);
            }

            writer.Close();
        }
    }
}
