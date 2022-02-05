using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class NoteList
    {
        private DataStorage _dataStorage;
        public NoteList()
        {
            _dataStorage = new DataStorage();
        }
        public void Add(string note)
        {
            if (string.IsNullOrEmpty(note))
            {
                throw new ArgumentException("Note cannot be empty");
            }

            _dataStorage.Save(note);
        }
    }
}
