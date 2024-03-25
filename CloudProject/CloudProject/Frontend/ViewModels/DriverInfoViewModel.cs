namespace Frontend.ViewModels;

public class DriverInfoViewModel
{
    public int driver_id { get; set; }

    public string driver_name { get; set; }

    public int is_reserve { get; set; }

    public string nationality { get; set; }

    public int season { get; set; }

    public int team_id { get; set; }

    public string team_name { get; set; }

    public DateTime updated { get; set; }
}