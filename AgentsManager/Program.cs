using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentsManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AgentDAL dal = new AgentDAL();
            dal.DeleteAgent(4);
        }
    }
}
