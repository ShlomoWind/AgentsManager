internal class Agent
{
    public int id { get; set;}
    public string codeName { get; set;}
    public string realNam { get; set;}
    public string location { get; set;}
    public string status { get; set;}
    public int missionsCompleted { get; set;}

    public Agent(int id, string codeName, string realName, string location, string status, int missionCompleted) 
    {
        this.id = id;
        this.codeName = codeName;
        this.realNam = realName;
        this.location = location;
        this.status = status;
        this.missionsCompleted = missionCompleted;
    }

}