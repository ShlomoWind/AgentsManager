using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

internal class AgentDAL
{
    private string connStr = "server=localhost;user=root;password=;database=eagleeyedb";
    private MySqlConnection conn;    
    public AgentDAL()
    {
        this.conn = new MySqlConnection(connStr); 
    }
    public MySqlCommand Command(string query)
    {
        MySqlCommand cmd = new MySqlCommand(query, this.conn);
        return cmd;

    }
    private void AddAgent(Agent agent)
    {
        string query = $"INSERT INTO eagleeyedb (id, codeName, realNam, location, status,missionsCompleted) VALUES ({agent.id},{agent.codeName},{agent.realNam},{agent.location},{agent.status},{agent.missionsCompleted})";
        this.Command(query);
    }
    private List<Agent> GetAllAgents()
    {
        string query = $"SELECT * FROM eagleeyedb";
        List<Agent> AllAgents = new List<Agent>();
        var cmd =  this.Command(query);
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Agent agent = new Agent(
                reader.GetInt32("id"),
                reader.GetString("codeName"),
                reader.GetString("realName"),
                reader.GetString("location"),
                reader.GetString("status"),
                reader.GetInt32("missionsCompleted")
                );
            AllAgents.Add(agent);
        }
        return AllAgents;
    }
    private void UpdateAgentLocation(int AgentId, string newLocation)
    {
        string query = $"UPDATE eagleeyedb location={newLocation} WHERE id={AgentId}";
        this.Command(query);
    }
    private void DeleteAgent(int agentId)
    {
        string query = $"DELETE FROM eagleeyedb WHERE id={agentId}";
        this.Command(query);
    }
} 