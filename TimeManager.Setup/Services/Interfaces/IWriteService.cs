using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Setup
{
    public interface IWriteService
    {
        public void Print(string msg);
        public void PrintInput(string msg);
        public void PrintAvailableCommands();
       
    }
}
