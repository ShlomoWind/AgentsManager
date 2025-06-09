using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentsManager.Models
{
    internal class Menu
    {
        private AgentDAL agent = new AgentDAL();
        public void ShowMenu()
        {
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Agent Management Menu ===");
                Console.WriteLine("1. Add Agent");
                Console.WriteLine("2. List All Agents");
                Console.WriteLine("3. Update Agent Location");
                Console.WriteLine("4. Delete Agent");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("id: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("codeName: ");
                        string codName = Console.ReadLine();
                        Console.Write("realName: ");
                        string realName = Console.ReadLine();
                        Console.Write("location: ");
                        string location = Console.ReadLine();
                        Console.Write("status: ");
                        string status = Console.ReadLine();
                        Console.Write("missionsCompleted: ");
                        int missionsCompleted = Convert.ToInt32(Console.ReadLine());
                        agent.AddAgent(new Agent(id,codName,realName,location,status,missionsCompleted));
                        break;
                    case "2":
                        List<Agent> agentList =  agent.GetAllAgents();
                        foreach(Agent agt in agentList)
                        {
                            Console.WriteLine($"id: {agt.id}, codeName: {agt.codeName}, realName: {agt.realName}, location: {agt.location}, status: {agt.status}, missionsCompleted: {agt.missionsCompleted}");
                        }
                        break;
                    case "3":
                        Console.Write("The ID of the agent you want to change the location of:");
                        int agtId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("The new location:");
                        string lction = Console.ReadLine();
                        agent.UpdateAgentLocation(agtId,lction);
                        break;
                    case "4":
                        Console.Write("ID of the agent you want to delete:");
                        int agntId = Convert.ToInt32(Console.ReadLine());
                        agent.DeleteAgent(agntId);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
