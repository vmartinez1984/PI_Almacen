using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DataStorage
    {
        internal void Save(string note)
        {
            using (StreamWriter writer = new StreamWriter("db.txt"))
            {
                writer.WriteLine(note);
            }
        }
    }
}