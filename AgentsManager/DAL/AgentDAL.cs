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
    public void AddAgent(Agent agent)
    {
        string query = $"INSERT INTO agents (id, codeName, realName, location, status,missionsCompleted) VALUES ({agent.id},'{agent.codeName}','{agent.realName}','{agent.location}','{agent.status}',{agent.missionsCompleted})";
        var cmd = this.Command(query);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    public List<Agent> GetAllAgents()
    {
        string query = $"SELECT * FROM agents";
        List<Agent> AllAgents = new List<Agent>();
        var cmd =  this.Command(query);
        conn.Open();
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
        conn.Close();
        return AllAgents;
    }
    public void UpdateAgentLocation(int AgentId, string newLocation)
    {
        string query = $"UPDATE agents SET location='{newLocation}' WHERE id={AgentId}";
        var cmd = this.Command(query);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    public void DeleteAgent(int agentId)
    {
        string query = $"DELETE FROM agents WHERE id={agentId}";
        var cmd = this.Command(query);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
} 