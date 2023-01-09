using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Setup
{
    public interface IInputService
    {
        public void Execute();
        public string GetAlias();
        public string GetCommand();
    }
}
