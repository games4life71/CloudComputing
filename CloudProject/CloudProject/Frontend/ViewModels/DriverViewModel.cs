namespace Frontend.ViewModels;

public class DriverViewModel
{
    public string id{get;set;}

    public string name{get;set;}

    public string team{get;set;}

    public DriverViewModel(string id, string name, string team)
    {
        this.id = id;
        this.name = name;
        this.team = team;
    }


}