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
        //the list of strings read
        public List<string> strings = new List<string>();

        //gets the directory of the debug folder(I guess it gets the deepest folder)
        string winDir = Environment.CurrentDirectory;

        public void Read(String _name)
        {
            StreamReader reader = new StreamReader(winDir + "\\" + _name + ".txt");//the reader for the file
            try
            {
                //this loop gets lines in the file and places them in the strings list until the file is empty
                while (reader.Peek() != -1)
                {
                    strings.Add(reader.ReadLine());
                }
            }
            catch
            {
                
            }
            finally
            {
                reader.Close();//close the reader
            }
        }

        //this function writes to the 
        public void Write(String _name, List<string> _strings)
        {
            //looks for the file to write to. If the file doesn't exist it is created
            StreamWriter writer = new StreamWriter(winDir + "\\" + _name + ".txt");

            //applies the _string var to the file specified
            foreach (string str in _strings) {
                writer.WriteLine(str);
            }

            //close it
            writer.Close();
        }
    }
}
